using NBA_Stats_API.Models;
using System.Collections.Generic;

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
