using System;

namespace Bang.Backend.Database.Entities
{
    public class Card
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public EType Type { get; set; }
        public ERank Rank { get; set; }
        public int Index { get; set; }

        public Guid? PlayerHandId { get; set; }
        public Player PlayerHand { get; set; }
        public Guid? PlayerDeskId { get; set; }
        public Player PlayerDesk { get; set; }

        public Guid? PackToTakeId { get; set; }
        public Game PackToTake { get; set; }
        public Guid? PackToLeaveId { get; set; }
        public Game PackToLeave { get; set; }
        public Guid? DeskId { get; set; }
        public Game Desk { get; set; }

        public enum EDestination
        {
            PlayerHand,
            PlayerDesk,
            PackToTake,
            PackToLeave,
            Desk
        }

        [Flags]
        public enum ERank
        {
            Club = 0,
            Diamond = 1,
            Heart = 2,
            Spade = 3,
            Two = 4,
            Three = 8,
            Four = 12,
            Five = 16,
            Six = 20,
            Seven = 24,
            Eight = 28,
            Nine = 32,
            Ten = 36,
            Jack = 40,
            Queen = 44,
            King = 48,
            Ace = 52
        }

        public enum EType
        {
            appaloosa,
            bang,
            barrel,
            beer,
            carabine,
            catbalou,
            diligenza,
            duel,
            dynamite,
            emporio,
            gatling,
            indians,
            jail,
            missed,
            mustang,
            panico,
            remington,
            saloon,
            schofield,
            volcanic,
            wellsfargo,
            winchester
        }
    }
}