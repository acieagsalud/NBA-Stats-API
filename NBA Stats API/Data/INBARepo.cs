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
        IEnumerable<Player> GetPlayerByName(string name);

        // Teams
        IEnumerable<Team> GetAllTeams();
        Team GetTeamById(int id);
        IEnumerable<Team> GetTeamByName(string name);
        IEnumerable<Player> GetAllPlayersOnTeam();
    }
}
