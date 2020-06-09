using System;
using System.Linq;
using Bang.Backend.Database;
using Bang.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Bang.Backend.Services
{
    public class CurrentPlayerMiddleware
    {
        public CurrentPlayerMiddleware()
        {

        }


#warning TODO: CurrentPlayerMiddleware
        private void LoadCurrentContext(DatabaseContext databaseContext, CurrentContext currentContext, string playerName, Guid gameId)
        {
            var player = databaseContext.Players
                .Include(p => p.Game)
                .FirstOrDefault(p => p.Name == playerName && p.GameId == gameId);

            currentContext.Player = player;
            currentContext.Game = player.Game;
        }
    }
}