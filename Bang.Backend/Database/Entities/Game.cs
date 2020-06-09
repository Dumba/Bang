using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bang.Backend.Database.Entities
{
    public class Game
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public EStatus Status { get; set; }

        public ICollection<Player> Players { get; set; } = new HashSet<Player>();

        public ICollection<Card> PackToTake { get; set; } = new HashSet<Card>();
        public ICollection<Card> PackToLeave { get; set; } = new HashSet<Card>();
        public ICollection<Card> Desk { get; set; } = new HashSet<Card>();

        public enum EStatus
        {
            Waiting,
            Running,
            Finished
        }
    }
}