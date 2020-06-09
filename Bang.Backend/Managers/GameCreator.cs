using System;
using System.Linq;
using Bang.Backend.Database.Entities;
using Bang.Backend.Database.Static;
using static Bang.Backend.Database.Entities.Card;

namespace Bang.Backend.Managers
{
    public class GameCreator
    {
        public GameCreator()
        {
            _random = new Random();
        }

        private readonly Random _random;

        public Card[] GenerateCards()
        {
            var cards = new Card[]
            {
                new Card { Type = EType.bang,      Rank = ERank.Club & ERank.Two, Index = _random.Next() },
                new Card { Type = EType.bang,      Rank = ERank.Club & ERank.Three, Index = _random.Next() },
                new Card { Type = EType.bang,      Rank = ERank.Club & ERank.Four, Index = _random.Next() },
                new Card { Type = EType.bang,      Rank = ERank.Club & ERank.Five, Index = _random.Next() },
                new Card { Type = EType.bang,      Rank = ERank.Club & ERank.Six, Index = _random.Next() },
                new Card { Type = EType.bang,      Rank = ERank.Club & ERank.Seven, Index = _random.Next() },
                new Card { Type = EType.bang,      Rank = ERank.Club & ERank.Eight, Index = _random.Next() },
                new Card { Type = EType.duel,      Rank = ERank.Club & ERank.Eight, Index = _random.Next() },
                new Card { Type = EType.bang,      Rank = ERank.Club & ERank.Nine, Index = _random.Next() },
                new Card { Type = EType.emporio,   Rank = ERank.Club & ERank.Nine, Index = _random.Next() },
                new Card { Type = EType.missed,    Rank = ERank.Club & ERank.Ten, Index = _random.Next() },
                new Card { Type = EType.volcanic,  Rank = ERank.Club & ERank.Ten, Index = _random.Next() },
                new Card { Type = EType.missed,    Rank = ERank.Club & ERank.Jack, Index = _random.Next() },
                new Card { Type = EType.schofield, Rank = ERank.Club & ERank.Jack, Index = _random.Next() },
                new Card { Type = EType.missed,    Rank = ERank.Club & ERank.Queen, Index = _random.Next() },
                new Card { Type = EType.schofield, Rank = ERank.Club & ERank.Queen, Index = _random.Next() },
                new Card { Type = EType.missed,    Rank = ERank.Club & ERank.King, Index = _random.Next() },
                new Card { Type = EType.remington, Rank = ERank.Club & ERank.King, Index = _random.Next() },
                new Card { Type = EType.missed,    Rank = ERank.Club & ERank.Ace, Index = _random.Next() },
                new Card { Type = EType.carabine,  Rank = ERank.Club & ERank.Ace, Index = _random.Next() },
                
                new Card { Type = EType.bang,      Rank = ERank.Diamond & ERank.Two, Index = _random.Next() },
                new Card { Type = EType.bang,      Rank = ERank.Diamond & ERank.Three, Index = _random.Next() },
                new Card { Type = EType.bang,      Rank = ERank.Diamond & ERank.Four, Index = _random.Next() },
                new Card { Type = EType.bang,      Rank = ERank.Diamond & ERank.Five, Index = _random.Next() },
                new Card { Type = EType.bang,      Rank = ERank.Diamond & ERank.Six, Index = _random.Next() },
                new Card { Type = EType.bang,      Rank = ERank.Diamond & ERank.Seven, Index = _random.Next() },
                new Card { Type = EType.bang,      Rank = ERank.Diamond & ERank.Eight, Index = _random.Next() },
                new Card { Type = EType.panico,    Rank = ERank.Diamond & ERank.Eight, Index = _random.Next() },
                new Card { Type = EType.bang,      Rank = ERank.Diamond & ERank.Nine, Index = _random.Next() },
                new Card { Type = EType.catbalou,  Rank = ERank.Diamond & ERank.Nine, Index = _random.Next() },
                new Card { Type = EType.bang,      Rank = ERank.Diamond & ERank.Ten, Index = _random.Next() },
                new Card { Type = EType.catbalou,  Rank = ERank.Diamond & ERank.Ten, Index = _random.Next() },
                new Card { Type = EType.bang,      Rank = ERank.Diamond & ERank.Jack, Index = _random.Next() },
                new Card { Type = EType.catbalou,  Rank = ERank.Diamond & ERank.Jack, Index = _random.Next() },
                new Card { Type = EType.bang,      Rank = ERank.Diamond & ERank.Queen, Index = _random.Next() },
                new Card { Type = EType.duel,      Rank = ERank.Diamond & ERank.Queen, Index = _random.Next() },
                new Card { Type = EType.bang,      Rank = ERank.Diamond & ERank.King, Index = _random.Next() },
                new Card { Type = EType.indians,   Rank = ERank.Diamond & ERank.King, Index = _random.Next() },
                new Card { Type = EType.bang,      Rank = ERank.Diamond & ERank.Ace, Index = _random.Next() },
                new Card { Type = EType.indians,   Rank = ERank.Diamond & ERank.Ace, Index = _random.Next() },
                
                new Card { Type = EType.dynamite,  Rank = ERank.Heart & ERank.Two, Index = _random.Next() },
                new Card { Type = EType.wellsfargo,Rank = ERank.Heart & ERank.Three, Index = _random.Next() },
                new Card { Type = EType.jail,      Rank = ERank.Heart & ERank.Four, Index = _random.Next() },
                new Card { Type = EType.saloon,    Rank = ERank.Heart & ERank.Five, Index = _random.Next() },
                new Card { Type = EType.beer,      Rank = ERank.Heart & ERank.Six, Index = _random.Next() },
                new Card { Type = EType.beer,      Rank = ERank.Heart & ERank.Seven, Index = _random.Next() },
                new Card { Type = EType.beer,      Rank = ERank.Heart & ERank.Eight, Index = _random.Next() },
                new Card { Type = EType.mustang,   Rank = ERank.Heart & ERank.Eight, Index = _random.Next() },
                new Card { Type = EType.beer,      Rank = ERank.Heart & ERank.Nine, Index = _random.Next() },
                new Card { Type = EType.mustang,   Rank = ERank.Heart & ERank.Nine, Index = _random.Next() },
                new Card { Type = EType.beer,      Rank = ERank.Heart & ERank.Ten, Index = _random.Next() },
                new Card { Type = EType.gatling,   Rank = ERank.Heart & ERank.Ten, Index = _random.Next() },
                new Card { Type = EType.beer,      Rank = ERank.Heart & ERank.Jack, Index = _random.Next() },
                new Card { Type = EType.panico,    Rank = ERank.Heart & ERank.Jack, Index = _random.Next() },
                new Card { Type = EType.bang,      Rank = ERank.Heart & ERank.Queen, Index = _random.Next() },
                new Card { Type = EType.panico,    Rank = ERank.Heart & ERank.Queen, Index = _random.Next() },
                new Card { Type = EType.bang,      Rank = ERank.Heart & ERank.King, Index = _random.Next() },
                new Card { Type = EType.catbalou,  Rank = ERank.Heart & ERank.King, Index = _random.Next() },
                new Card { Type = EType.bang,      Rank = ERank.Heart & ERank.Ace, Index = _random.Next() },
                new Card { Type = EType.panico,    Rank = ERank.Heart & ERank.Ace, Index = _random.Next() },
                
                new Card { Type = EType.missed,    Rank = ERank.Spade & ERank.Two, Index = _random.Next() },
                new Card { Type = EType.missed,    Rank = ERank.Spade & ERank.Three, Index = _random.Next() },
                new Card { Type = EType.missed,    Rank = ERank.Spade & ERank.Four, Index = _random.Next() },
                new Card { Type = EType.missed,    Rank = ERank.Spade & ERank.Five, Index = _random.Next() },
                new Card { Type = EType.missed,    Rank = ERank.Spade & ERank.Six, Index = _random.Next() },
                new Card { Type = EType.missed,    Rank = ERank.Spade & ERank.Seven, Index = _random.Next() },
                new Card { Type = EType.missed,    Rank = ERank.Spade & ERank.Eight, Index = _random.Next() },
                new Card { Type = EType.winchester,Rank = ERank.Spade & ERank.Eight, Index = _random.Next() },
                new Card { Type = EType.diligenza, Rank = ERank.Spade & ERank.Nine, Index = _random.Next() },
                new Card { Type = EType.diligenza, Rank = ERank.Spade & ERank.Nine, Index = _random.Next() },
                new Card { Type = EType.jail,      Rank = ERank.Spade & ERank.Ten, Index = _random.Next() },
                new Card { Type = EType.volcanic,  Rank = ERank.Spade & ERank.Ten, Index = _random.Next() },
                new Card { Type = EType.jail,      Rank = ERank.Spade & ERank.Jack, Index = _random.Next() },
                new Card { Type = EType.duel,      Rank = ERank.Spade & ERank.Jack, Index = _random.Next() },
                new Card { Type = EType.barrel,    Rank = ERank.Spade & ERank.Queen, Index = _random.Next() },
                new Card { Type = EType.emporio,   Rank = ERank.Spade & ERank.Queen, Index = _random.Next() },
                new Card { Type = EType.barrel,    Rank = ERank.Spade & ERank.King, Index = _random.Next() },
                new Card { Type = EType.schofield, Rank = ERank.Spade & ERank.King, Index = _random.Next() },
                new Card { Type = EType.bang,      Rank = ERank.Spade & ERank.Ace, Index = _random.Next() },
                new Card { Type = EType.appaloosa, Rank = ERank.Spade & ERank.Ace, Index = _random.Next() },
            };

            var result = cards.OrderBy(c => c.Index).ToArray();

            return result;
        }

        public ERole[] GenerateRoles(int playerCount)
        {
            ERole[] roles;
            switch (playerCount)
            {
                case 4:
                    roles = new ERole[] { ERole.sheriff, ERole.outlaw, ERole.outlaw, ERole.renegade };
                    break;
                case 5:
                    roles = new ERole[] { ERole.sheriff, ERole.outlaw, ERole.outlaw, ERole.renegade, ERole.vice };
                    break;
                case 6:
                    roles = new ERole[] { ERole.sheriff, ERole.outlaw, ERole.outlaw, ERole.outlaw, ERole.renegade, ERole.vice };
                    break;
                case 7:
                    roles = new ERole[] { ERole.sheriff, ERole.outlaw, ERole.outlaw, ERole.outlaw, ERole.renegade, ERole.vice, ERole.vice };
                    break;
                default:
                    throw new Exception("Invalid player count");
            }

            roles = roles.OrderBy(r => _random.Next()).ToArray();

            return roles;
        }

        public ECharacter[] GenerateCharacters()
        {
            var characters = Enum.GetValues(typeof(ECharacter))
                .Cast<ECharacter>()
                .OrderBy(c => _random.Next())
                .ToArray();

            return characters;
        }
    }
}