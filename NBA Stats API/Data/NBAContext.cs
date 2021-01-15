using Microsoft.EntityFrameworkCore;
using NBA_Stats_API.Models;

namespace NBA_Stats_API.Data
{
    public class NBAContext : DbContext
    {
        public NBAContext(DbContextOptions<NBAContext> options) : base(options)
        {

        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
