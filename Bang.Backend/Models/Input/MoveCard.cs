using System;
using Bang.Backend.Database.Entities;

namespace Bang.Backend.Models.Input
{
    public class MoveCard
    {
        public Guid CardId { get; set; }
        public Card.EDestination Destination { get; set; }
        public Guid? DestinationId { get; set; }
    }
}