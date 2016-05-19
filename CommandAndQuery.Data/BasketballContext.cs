using System.Data.Entity;
using CommandAndQuery.Domain.Models;

namespace CommandAndQuery.Data
{
    public class BasketballContext : DbContext
    {
        public DbSet<BasketballTeam> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}