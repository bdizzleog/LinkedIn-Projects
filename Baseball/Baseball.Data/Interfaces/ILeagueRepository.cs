using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baseball.Models;

namespace Baseball.Data.Interfaces
{
    public interface ILeagueRepository
    {
        List<League> GetAllLeagues();
        void AddLeague(League league);
        void EditLeague(League league);
        void RemoveLeagueById(int id);
       
    }
}
