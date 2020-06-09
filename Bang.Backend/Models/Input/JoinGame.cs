using System;

namespace Bang.Backend.Models.Input
{
    public class JoinGame
    {
        public string PlayerName { get; set; }
        public Guid GameId { get; set; }
    }
}