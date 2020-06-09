using System.Linq;
using Bang.Backend.Database.Entities;
using Bang.Backend.Models;

namespace Bang.Backend.Services
{
    public class ModelBuilder
    {
        public GameList ToListModel(Game game)
        {
            var gameModel = new GameList
            {
                Id = game.Id,
                PlayerNames = game.Players.Select(p => p.Name).ToArray()
            };

            return gameModel;
        }

        public GameModel ToDetailModel(Game game)
        {
            var gameDetail = new GameModel
            {

            };

            return gameDetail;
        }
    }
}