using System;
using System.Collections.Generic;

namespace Bang.Backend.Models
{
    public class PlayerModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Role { get; set; }
        public string Character { get; set; }
        public int HP { get; set; }

        public IEnumerable<Guid> CardInHand { get; set; }
        public IEnumerable<Guid> CardOnDesk { get; set; }
    }
}