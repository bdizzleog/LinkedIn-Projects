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
    public class TeamManager
    {
        private static ITeamRepository _teamrepo;
        private static IPlayerRepository _playerRepo;

        public TeamManager()
        {
            _teamrepo = new Factory().TeamRepository();
            _playerRepo = new Factory().PlayerRepository();
        }
        public List<Team> GetAllTeams()
        {
          return  _teamrepo.GetAllTeams();      
        }

        public void AddTeam(Team team)
        {
           
            if (GetAllTeams().Count == 0)
            {
                team.Id = 1;
            }
            else
            {
                team.Id = GetAllTeams().LastOrDefault().Id + 1;
            }
            team.Players = new List<Player>();
            _teamrepo.AddTeam(team);           
        }

        public Team GetTeamById(int id)
        {
           // return _teamrepo.GetAllTeams().First(p => p.Id == id);

            var teams = _teamrepo.GetAllTeams();
            var team = teams.FirstOrDefault(t => t.Id == id);
            return team;
        }

        public void DeleteTeam(int id)
        {
            var team = _teamrepo.GetAllTeams().First(t => t.Id == id);

            if (team.Id != 0 && team.Players != null)
            {
                foreach (var player in team.Players)
                {
                    player.TeamId = 0;
                    PlayerToFreeAgency(player);
                }
            }

            if (team.Id != 0)
            {
               _teamrepo.DeleteTeam(team.Id);
            }
            
            
        }

        public void CutPlayer(int id)
        {
            
        }

    

        public void EditTeam(Team team)

        {
            _teamrepo.EditTeam(team);
        }

        public void TradePlayers(Team team1, Team team2, Player player1, Player player2)
        {
            int x =  player1.TeamId;
            player1.TeamId = player2.TeamId;
            player2.TeamId = x;
            team1.Players.Remove(player1);
            team2.Players.Remove(player2);
            team1.Players.Add(player2);
            team2.Players.Add(player1);
        }

        /// <summary>
        /// this method will add players to the free agency
        /// </summary>
        /// <param name="player"></param>
        public void PlayerToFreeAgency(Player player)
        {
            var team = GetTeamById(0);

            team.Players.Add(player);
        }

        
    }
}
