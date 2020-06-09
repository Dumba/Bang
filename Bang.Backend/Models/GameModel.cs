using System;
using System.Collections.Generic;

namespace Bang.Backend.Models
{
    public class GameModel
    {
        public IEnumerable<PlayerModel> Players { get; set; }
        public IEnumerable<Guid> CardsOnDesk { get; set; }
        public IEnumerable<Guid> PackToTake { get; set; }
        public IEnumerable<Guid> PackToLeave { get; set; }
        public IEnumerable<CardModel> Cards { get; set; }
    }
}