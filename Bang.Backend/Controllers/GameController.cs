using System.Linq;
using Bang.Backend.Database;
using Microsoft.AspNetCore.Mvc;
using Bang.Backend.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Bang.Backend.Managers;
using Bang.Backend.Models;
using Bang.Backend.Models.Input;

namespace Bang.Backend.Controllers
{
    public class GameController : Controller
    {
        public GameController(CurrentContext currentContext, DatabaseContext databaseContext, GameManager gameManager)
        {
            _currentContext = currentContext;
            _databaseContext = databaseContext;
            _gameManager = gameManager;
            _modelBuilder = new Services.ModelBuilder();
        }

        private readonly CurrentContext _currentContext;
        private readonly DatabaseContext _databaseContext;
        private readonly GameManager _gameManager;
        private readonly Services.ModelBuilder _modelBuilder;

        public IActionResult Init()
        {
            var waitingGames = _databaseContext.Games
                .Include(g => g.Players)
                .Where(g => g.Status == Game.EStatus.Waiting)
                .ToArray();

            var gameModels = waitingGames.Select(_modelBuilder.ToListModel);

            return Ok(gameModels);
        }
        public IActionResult CreateGame(CreateGame input)
        {
            _gameManager.CreateGameAndUser(input.PlayerName);
            _databaseContext.SaveChanges();

            var gameModel = _modelBuilder.ToDetailModel(_currentContext.Game);

            return Ok(gameModel);
        }
        public IActionResult JoinGame(JoinGame input)
        {
            _gameManager.JoinGame(input.PlayerName, input.GameId);

            var gameModel = _modelBuilder.ToDetailModel(_currentContext.Game);

            return Ok(gameModel);
        }
        public IActionResult StartGame()
        {
            _gameManager.StartGame();

            return Ok();
        }

        public IActionResult SelectCharacter(SelectCharacter input)
        {
            _gameManager.SelectCharacter(input.Character);

            return Ok();
        }

        public IActionResult MoveCard(MoveCard input)
        {
            var card = _databaseContext.Cards.Find(input.CardId);

            _gameManager.MoveCard(card, input.Destination, input.DestinationId);
            _databaseContext.SaveChanges();

            return Ok();
        }
        public IActionResult ChangeHP(ChangeHP input)
        {
            _gameManager.ChangeHP(input.ToHP);

            return Ok();
        }
    }
}