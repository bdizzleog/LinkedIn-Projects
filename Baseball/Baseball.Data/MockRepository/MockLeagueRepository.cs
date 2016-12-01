using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baseball.Data.Interfaces;
using Baseball.Models;

namespace Baseball.Data.MockRepository
{
    public class MockLeagueRepository : ILeagueRepository

    {
        private static List<League> _leagues;

        static MockLeagueRepository()
        {
            _leagues = new List<League>()
            {
                new League()
                {
                    Id = 0,
                    Name = "Not in League"
                },
                new League()
                {
                    Id = 1,
                    Name = "American League"
                },
                new League()
                {
                    Id = 2,
                    Name = "National League"
                }
            };
        }


        public void AddLeague(League league)
        {
            _leagues.Add(league);
        }

        public void EditLeague(League league)
        {
            var selectedLeague = _leagues.FirstOrDefault(l => l.Id == league.Id);
            selectedLeague.Name = league.Name;
        }

        public League Get(int id)
        {
            return _leagues.FirstOrDefault(l => l.Id == id);
        }

        public List<League> GetAllLeagues()
        {
            return _leagues;
        }

        public void RemoveLeagueById(int id)
        {
            _leagues.RemoveAll(l => l.Id == id);
        }
    }
}
