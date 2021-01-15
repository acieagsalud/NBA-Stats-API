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
        public IEnumerable<Player> GetPlayerByName(string name)
        {
            return _context.Players
                .Include(t => t.Team)
                .Where(p => p.FirstName.Contains(name) || p.LastName.Contains(name))
                .ToList();
        }

        public Team GetTeamById(int id)
        {
            return _context.Teams.FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<Team> GetTeamByName(string name)
        {
            return _context.Teams.Where(t => t.Name.Contains(name)).ToList();
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
