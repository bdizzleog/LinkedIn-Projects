using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baseball.Models;

namespace Baseball.Data.Interfaces
{
    public interface ITeamRepository
    {
        List<Team> GetAllTeams();
        void AddTeam(Team team);
        void DeleteTeam(int id);
        void EditTeam(Team team);        
    }
}
