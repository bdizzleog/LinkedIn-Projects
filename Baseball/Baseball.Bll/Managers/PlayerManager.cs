using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baseball.Data;
using Baseball.Data.FileRepository;
using Baseball.Data.Interfaces;
using Baseball.Models;

namespace Baseball.Bll.Managers
{
    public class PlayerManager
    {

        private static IPlayerRepository _playerRepo;
        private static ITeamRepository _teamRepository;


        public PlayerManager()
        {
            _playerRepo = new Factory().PlayerRepository();
            _teamRepository = new Factory().TeamRepository();
        }

        public void AddPlayerToRepo(Player player)
        {
            if (GetAllPlayers().Count != 0)
            {
                player.Id = GetAllPlayers().LastOrDefault().Id + 1;
            }
            else
            {
                player.Id = 1;
            }
            _playerRepo.AddPlayer(player);
             SetToFreeAgent(player);

        }

        public void EditPlayer(Player player)
        {
            var team = _teamRepository.GetAllTeams().FirstOrDefault(t => t.Id == player.TeamId);
            team.Players.RemoveAll(t => t.Id == player.Id);       
            _playerRepo.EditPlayer(player);
            team.Players.Add(player);
           
        }

        public void RemovePlayerById(int id)
        {
            var manager = new TeamManager();
            var player = _playerRepo.GetAllPlayers().FirstOrDefault(p => p.Id == id);
            var team = manager.GetTeamById(player.TeamId);
            team.Players.RemoveAll(p => p.Id == player.Id);
            _playerRepo.RemovePlayerById(id);

        }
        //public void CutPlayerById(int id)
        //{
        //    var manager = new TeamManager();
        //    var player = _playerRepo.GetAllPlayers().FirstOrDefault(p => p.Id == id);
        //    var team = manager.GetTeamById(player.TeamId);
        //    team.Players.RemoveAll(p => p.Id == player.Id);
        //    var freeagency = _teamRepository.GetAllTeams().FirstOrDefault(f => f.Id == 0);
        //    freeagency.Players.Add(player);
        //}

        //// public void RemovePlayerFromTeamById(int id)
        // {
        //     var player = GetPlayerById(id);


        //     var team = _teamRepository.GetAllTeams().FirstOrDefault(t => t.Id == player.TeamId);

        //     if (team != null)
        //     {
        //         team.Players.Remove(player);
        //         _teamRepository.EditTeam(team);
        //     }




        //_playerRepo.RemovePlayerById(id);
        //}

        public void AddPlayerToTeam(Player player)
        {
            var team = _teamRepository.GetAllTeams().FirstOrDefault(t => t.Id == player.TeamId);
            team.Players.Add(player);
            _teamRepository.EditTeam(team);
        }

        public Player GetPlayerById(int id)
        {
            return GetAllPlayers().FirstOrDefault(p => p.Id == id);
        }

        public List<Player> GetAllPlayers()
        {
            return _playerRepo.GetAllPlayers();
        }

        public void SetToFreeAgent(Player player)
        {
            player.TeamId = 0;
            var freeagency = _teamRepository.GetAllTeams().FirstOrDefault(t => t.Id == 0);
            freeagency.Players.Add(player);       
        }

    }


}
