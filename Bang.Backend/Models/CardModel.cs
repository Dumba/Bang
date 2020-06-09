using System;

namespace Bang.Backend.Models
{
    public class CardModel
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
    }
}