using Bang.Backend.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bang.Backend.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>()
                .HasOne<Player>(c => c.PlayerHand)
                .WithMany(p => p.CardsInHand)
                .HasForeignKey(c => c.PlayerHandId);
            modelBuilder.Entity<Card>()
                .HasOne<Player>(c => c.PlayerDesk)
                .WithMany(p => p.CardsOnDesk)
                .HasForeignKey(c => c.PlayerDeskId);
            modelBuilder.Entity<Card>()
                .HasOne<Game>(c => c.PackToTake)
                .WithMany(g => g.PackToTake)
                .HasForeignKey(c => c.PackToTakeId);
            modelBuilder.Entity<Card>()
                .HasOne<Game>(c => c.PackToLeave)
                .WithMany(g => g.PackToLeave)
                .HasForeignKey(c => c.PackToLeaveId);
            modelBuilder.Entity<Card>()
                .HasOne<Game>(c => c.Desk)
                .WithMany(g => g.Desk)
                .HasForeignKey(c => c.DeskId);

            modelBuilder.Entity<Player>()
                .HasOne<Game>(p => p.Game)
                .WithMany(g => g.Players)
                .HasForeignKey(p => p.GameId);
        }
    }
}