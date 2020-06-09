using System;
using System.Linq;
using Bang.Backend.Database;
using Bang.Backend.Database.Entities;
using Bang.Backend.Database.Static;
using Bang.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Bang.Backend.Managers
{
    public class GameManager
    {
        private static object _cardLock = new object();

        public GameManager(CurrentContext currentContext, DatabaseContext databaseContext)
        {
            _gameCreator = new GameCreator();
            _currentContext = currentContext;
            _databaseContext = databaseContext;
        }

        private readonly GameCreator _gameCreator;
        private readonly CurrentContext _currentContext;
        private readonly DatabaseContext _databaseContext;

        public void CreateGameAndUser(string playerName)
        {
            var game = new Game();
            var player = new Player
            {
                Name = playerName,
                Game = game
            };

            _databaseContext.Add(game);
            _databaseContext.Add(player);

            _currentContext.Game = game;
            _currentContext.Player = player;
        }

        public void JoinGame(string playerName, Guid gameId)
        {
            // get already logged player - reconnect
            var player = _databaseContext.Players
                .Include(p => p.Game)
                .FirstOrDefault(p => p.Name == playerName && p.GameId == gameId);
            var game = player?.Game;

            // new player
            if (player == null)
            {
                game = _databaseContext.Games.Find(gameId)
                    ?? throw new Exception("Game not found");

                player = new Player
                {
                    Name = playerName,
                    Game = game
                };
                _databaseContext.Add(player);
            }

            _currentContext.Player = player;
            _currentContext.Game = game;
        }

        public void StartGame()
        {
            /// cards
            _currentContext.Game.PackToTake = _gameCreator.GenerateCards();

            /// players
            // get
            var players = _databaseContext.Players
                .Where(p => p.GameId == _currentContext.Game.Id)
                .ToArray();

            // init
            var random = new Random();
            var roles = _gameCreator.GenerateRoles(players.Length);
            var characters = _gameCreator.GenerateCharacters();

            // set
            int i = 0;
            foreach (var player in players.OrderBy(p => random.Next()))
            {
                player.Index = i;
                player.Role = roles[i];
                player.Character = characters[i] | characters[i + players.Length];

                i++;
            }
        }

        public void SelectCharacter(ECharacter character)
        {
            // check
            if ((_currentContext.Player.Character & character) == 0)
                throw new Exception("Invalid character");

            // set character
            _currentContext.Player.Character = character;
            _currentContext.Player.HP = character.GetHP();
            if (_currentContext.Player.Role == ERole.sheriff)
                _currentContext.Player.HP++;

            // get cards
            var packToTake = _databaseContext.Cards
                .Where(c => c.PackToTakeId == _currentContext.Game.Id)
                .OrderBy(c => c.Index)
                .Take(character.GetHP())
                .Select((card, index) => new { card, index } );
            foreach (var pair in packToTake)
            {
                pair.card.PackToTakeId = null;
                pair.card.PlayerHandId = _currentContext.Player.Id;
                pair.card.Index = pair.index;
            }
        }

        public void MoveCard(Card card, Card.EDestination destination, Guid? destinationId)
        {
            switch (destination)
            {
                case Card.EDestination.PlayerHand:
                    card.PlayerHandId = destinationId.Value;
                    break;
                case Card.EDestination.PlayerDesk:
                    card.PlayerDeskId = destinationId.Value;
                    break;
                case Card.EDestination.PackToTake:
                    card.PackToTakeId = _currentContext.Game.Id;
                    break;
                case Card.EDestination.PackToLeave:
                    card.PackToLeaveId = _currentContext.Game.Id;
                    break;
                case Card.EDestination.Desk:
                    card.DeskId = _currentContext.Game.Id;
                    break;
                default:
                    throw new InvalidOperationException("Unknown destination");
            }
        }

        public void ChangeHP(int toHP)
        {
            var player = _currentContext.Player;

            player.HP = toHP;
        }
    }
}