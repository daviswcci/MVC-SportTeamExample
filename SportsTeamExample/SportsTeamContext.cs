using Microsoft.EntityFrameworkCore;
using SportsTeamExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsTeamExample
{
    public class SportsTeamContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<PlayerPosition> PlayerPositions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=(localdb)\\mssqllocaldb; Database=SportsDB_06252021; Trusted_Connection=True";

            optionsBuilder.UseSqlServer(connectionString).UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // this is where we add seed data 
            modelBuilder.Entity<Player>().HasData(
                new Player() {Id = 1, Name = "LeBron James", Number = 6, TeamId = 1 },
                new Player() { Id = 2, Name = "Bugs Bunny", Number = 10, TeamId = 1 },
                new Player() { Id = 3, Name = "Devin Booker", Number = 13, TeamId = 2 }
                );
            modelBuilder.Entity<Team>().HasData(
                new Team() { Id = 1, Name = "Tune Squad", City = "Tune World" },
                new Team(2, "Suns", "Phoenix")
                );
            modelBuilder.Entity<Position>().HasData(
                new Position() { Id = 1, Name = "Point Guard"},
                new Position() { Id = 2, Name = "Shooting Guard" },
                new Position() { Id = 3, Name = "Small Forward" },
                new Position() { Id = 4, Name = "Power Forward" },
                new Position() { Id = 5, Name = "Center" }
                );
            modelBuilder.Entity<PlayerPosition>().HasData(
                new PlayerPosition() { Id = 1, PlayerId = 1, PositionId = 1},
                new PlayerPosition() { Id = 2, PlayerId = 1, PositionId = 3 },
                new PlayerPosition() { Id = 3, PlayerId = 3, PositionId = 2 },
                new PlayerPosition() { Id = 4, PlayerId = 2, PositionId = 4 },
                new PlayerPosition() { Id = 5, PlayerId = 2, PositionId = 3 }
                );
        }
    }
}
