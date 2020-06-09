using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Bang.Backend.Database.Static;

namespace Bang.Backend.Database.Entities
{
    public class Player
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [StringLength(50)]
        public string Name { get; set; }
        public ERole Role { get; set; }
        public ECharacter Character { get; set; }
        public int HP { get; set; }
        public int Index { get; set; }

        public Guid GameId { get; set; }
        public Game Game { get; set; }

        public ICollection<Card> CardsInHand { get; set; } = new HashSet<Card>();
        public ICollection<Card> CardsOnDesk { get; set; } = new HashSet<Card>();
    }
}