using Microsoft.EntityFrameworkCore;
using NBA_Stats_API.Models;
using System.Collections.Generic;
using System.Linq;

namespace NBA_Stats_API.Data
{
    public class SqlNBARepo : INBARepo
    {
        private readonly NBAContext _context;

        public SqlNBARepo(NBAContext context)
        {
            _context = context;
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            return _context.Players
                .Include(t => t.Team)
                .ToList();
        }

        public IEnumerable<Player> GetAllPlayersOnTeam()
        {
            return _context.Players.ToList();
        }

        public IEnumerable<Team> GetAllTeams()
        {
            return _context.Teams.ToList();
        }

        public Player GetPlayerById(int id)
        {
            return _context.Players.FirstOrDefault(p => p.Id == id);
        }

        public Team GetTeamById(int id)
        {
            return _context.Teams.FirstOrDefault(t => t.Id == id);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdatePlayer(Player player)
        {
            
        }
    }
}
