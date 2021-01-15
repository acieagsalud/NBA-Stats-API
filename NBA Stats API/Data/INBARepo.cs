using NBA_Stats_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBA_Stats_API.Data
{
    public interface INBARepo
    {
        bool SaveChanges();
        
        // Players
        IEnumerable<Player> GetAllPlayers();
        Player GetPlayerById(int id);
        void UpdatePlayer(Player player);

        // Teams
        IEnumerable<Team> GetAllTeams();
        Team GetTeamById(int id);
        IEnumerable<Player> GetAllPlayersOnTeam();
    }
}
