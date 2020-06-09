using Bang.Backend.Database.Entities;

namespace Bang.Backend.Models
{
    public class CurrentContext
    {
        public Player Player { get; set; }
        public Game Game { get; set; }
    }
}