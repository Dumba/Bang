using System;

namespace Bang.Backend.Models
{
    public class GameList
    {
        public Guid Id { get; set; }
        public string[] PlayerNames { get; set; }
    }
}