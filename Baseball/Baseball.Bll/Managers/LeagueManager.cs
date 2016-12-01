using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baseball.Data;
using Baseball.Data.Interfaces;
using Baseball.Models;

namespace Baseball.Bll.Managers
{
    public class LeagueManager
    {
        private static ITeamRepository _teamrepo;
        private static IPlayerRepository _playerRepo;
        private static ILeagueRepository _leaguerepo;

        public LeagueManager()
        {
            _playerRepo = new Factory().PlayerRepository();
            _teamrepo = new Factory().TeamRepository();
            _leaguerepo = new Factory().LeagueRepository();
        }

        public List<League> GetAllLeagues()
        {
            return _leaguerepo.GetAllLeagues();
        }

        public League GetLeagueById(int id)
        {

            return GetAllLeagues().FirstOrDefault(l => l.Id == id);
        }

        public void EditLeague(League league)
        {
            _leaguerepo.EditLeague(league);
        }

        public void DeleteLeagueById(int id)
        {
            var league = GetLeagueById(id);
            var teams = _teamrepo.GetAllTeams().Where(t => t.LeagueId == league.Id);
            
            foreach (var team in teams)
            {
                team.LeagueId = 0;
            }
            if (league.Id != 0)
            {
                _leaguerepo.RemoveLeagueById(league.Id);
            }
        }

        public void AddLeague(League league)
        {
            if (GetAllLeagues().Count != 0)
            {
                league.Id = GetAllLeagues().LastOrDefault().Id + 1;
            }
            else
            {
                league.Id = 1;
            }
            _leaguerepo.AddLeague(league);          
        }

    }
}
