using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Baseball.Bll.Managers;
using Baseball.Data;
using Baseball.Data.Interfaces;
using Baseball.Data.MockRepository;
using Baseball.Models;
using Baseball.Models.ViewModels;

namespace Baseball.Web.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [HttpGet]
        public ActionResult AdminLandingPage()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Players()
        {
            var manager = new PlayerManager();
            var players = manager.GetAllPlayers();
            players = players.OrderBy(p => p.LastName).ToList();

            return View(players);
        }

        [HttpGet]
        public ActionResult AddPlayer()
        {
            return View(new Player());
        }

        [HttpPost]
        public ActionResult AddPlayer(Player player)
        {
            if (ModelState.IsValid)
            {
                var manager = new PlayerManager();
                manager.AddPlayerToRepo(player);
                return RedirectToAction("Players");
            }
            return View();
        }

        //[HttpGet]
        //public ActionResult AddPlayerToTeam(int id)
        //{

        //}

        //[HttpPost]
        //public ActionResult AddPlayerToTeam(AddPlayerToTeamVM playerVM)
        //{

        //}

        [HttpGet]
        public ActionResult EditPlayer(int id)
        {
            var manager = new PlayerManager();
            var player = manager.GetPlayerById(id);

            return View(player);
        }

        [HttpPost]
        public ActionResult EditPlayer(Player player)
        {
            if (ModelState.IsValid)
            {
                var manager = new PlayerManager();
                manager.EditPlayer(player);
                return RedirectToAction("Players");
            }

            return View();
        }

        [HttpGet]
        public ActionResult DeletePlayer(int id)
        {
            var manager = new PlayerManager();
            var player = manager.GetPlayerById(id);

            return View(player);
        }

        [HttpPost]
        public ActionResult DeletePlayer(Player player)
        {
            var manager = new PlayerManager();
            manager.RemovePlayerById(player.Id);

            return RedirectToAction("Players");
        }

        // List of the teams
        [HttpGet]
        public ActionResult Teams()
        {
            var manager = new TeamManager();
            var teams = manager.GetAllTeams();

            return View(teams);
        }

        [HttpGet]
        public ActionResult ViewRoster(int id)
        {
            var leagueManager = new LeagueManager();
            var manager = new TeamManager();
            var roster = manager.GetTeamById(id);

            var teamVM = new TeamVM();
            teamVM.Team = roster;
            teamVM.TeamLeague = leagueManager.GetLeagueById(teamVM.Team.LeagueId);
            teamVM.FreeAgents = manager.GetTeamById(0);
            teamVM.Team.Players = roster.Players.OrderBy(t => t.LastName).ToList();


            return View(teamVM);
        }

        [HttpGet]
        public ActionResult ViewPlayer(int id)
        {
            var manager = new PlayerManager();
            var player = manager.GetPlayerById(id);

            return View(player);
        }

        [HttpGet]
        public ActionResult AddTeam()
        {
            return View(new Team());
        }

        [HttpPost]
        public ActionResult AddTeam(Team team)
        {
            if (ModelState.IsValid)
            {
                var manager = new TeamManager();
                manager.AddTeam(team);

                return RedirectToAction("Teams");
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditTeam(int id)
        {
            var manager = new TeamManager();
            var editTeam = manager.GetTeamById(id);



            return View(editTeam);
        }

        [HttpPost]
        public ActionResult EditTeam(Team team)
        {
            if (ModelState.IsValid)
            {
                var manager = new TeamManager();
                manager.EditTeam(team);

                return RedirectToAction("Teams");
            }
            return View();
        }

        
        [HttpGet]
        public ActionResult DeleteTeam(int id)
        {
            var manager = new TeamManager();
            var team = manager.GetTeamById(id);

            return View(team);

        }

       
        [HttpPost]
        public ActionResult DeleteTeam(Team team)
        {
            var manager = new TeamManager();
            manager.DeleteTeam(team.Id);

            return RedirectToAction("Teams");
        }

        [HttpGet]
        public ActionResult Leagues()
        {
            var manager = new LeagueManager();
            var league = manager.GetAllLeagues();

            return View(league);
        }

        [HttpGet]
        public ActionResult AddLeague()
        {
            return View(new League());
        }

        [HttpPost]
        public ActionResult AddLeague(League league)
        {


            if (ModelState.IsValid)
            {
                var manager = new LeagueManager();
                manager.AddLeague(league);
                return RedirectToAction("Leagues");
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditLeague(int id)
        {
            var manager = new LeagueManager();
            League league = new League();
            league.Id = id;
            var editLeague = manager.GetLeagueById(league.Id);

            return View(editLeague);
        }

        [HttpPost]
        public ActionResult EditLeague(League league)
        {
            if (ModelState.IsValid)
            {
                var manager = new LeagueManager();
                manager.EditLeague(league);
                return RedirectToAction("Leagues");
            }

            return View();
        }

        [HttpGet]
        public ActionResult DeleteLeague(int id)
        {
            var manager = new LeagueManager();
            var league = manager.GetLeagueById(id);

            return View(league);
        }

        [HttpPost]
        public ActionResult DeleteLeague(League league)
        {
            var manager = new LeagueManager();
            manager.DeleteLeagueById(league.Id);

            return RedirectToAction("Leagues");
        }
      
        [HttpGet]
        public ActionResult ViewLeague(int id)
        {
            var leagueManager = new LeagueManager();
            var manager = new TeamManager();
            var league = leagueManager.GetLeagueById(id);
            var leagueVM = new LeagueVM();
            leagueVM.League = league;
            leagueVM.TeamsInLeague = manager.GetAllTeams().FindAll(t => t.LeagueId == leagueVM.League.Id);
            return View(leagueVM);
        }

        [HttpGet]
        public ActionResult AddFreeAgentToTeam(int id)
        {
            var teamManager = new TeamManager();
            var playerManager = new PlayerManager();
            var vm = new AddFreeAgentToTeamVM();
            vm.TeamToAddPlayer = teamManager.GetAllTeams().FirstOrDefault(t => t.Id == id);
            vm.TeamToRemovePlayer = teamManager.GetTeamById(0);
           // vm.TeamToRemovePlayer.Players = playerManager.GetAllPlayers().FindAll(p => p.TeamId == 0);
            vm.SetPlayerList(vm.TeamToRemovePlayer.Players);
            vm.SetTeamRoster(vm.TeamToAddPlayer.Players);


            return View(vm);
        }

        [HttpPost]
        public ActionResult AddFreeAgentToTeam(AddFreeAgentToTeamVM vm)
        {
            var teamManager = new TeamManager();
            var playerManager = new PlayerManager();
            var freeagency = teamManager.GetTeamById(0);
            var team = teamManager.GetAllTeams().FirstOrDefault(t => t.Id == vm.TeamToAddPlayer.Id);
            team.Players.Clear();


            if (vm.PlayersToAdd != null && vm.PlayersToAdd.Count > 0)
            {
                foreach (var playerid in vm.PlayersToAdd)
                {
                    freeagency.Players.RemoveAll(p => p.Id == playerid);
                    team.Players.Add(playerManager.GetPlayerById(playerid));
                    var player = playerManager.GetPlayerById(playerid);
                    player.TeamId = team.Id;
                }
            }

            return RedirectToAction("AddFreeAgentToTeam");
        }

        [HttpGet]
        public ActionResult CutPlayerToFreeAgency(int id)
        {
            var teamManager = new TeamManager();
            var playerManager = new PlayerManager();
            var vm = new CutPlayerToFreeAgencyVM();
            vm.FreeAgency = teamManager.GetTeamById(0);
            vm.TeamToRemovePlayer = teamManager.GetTeamById(id);
            vm.TeamToRemovePlayer.Players = playerManager.GetAllPlayers().FindAll(p => p.TeamId == id);
            vm.SetPlayerList(vm.TeamToRemovePlayer.Players);
            vm.SetFreeAgency(vm.FreeAgency.Players);
            return View(vm);
        }

        [HttpPost]
        public ActionResult CutPlayerToFreeAgency(CutPlayerToFreeAgencyVM vm)
        {
            var teamManager = new TeamManager();
            var playerManager = new PlayerManager();
            var teamToRemovePlayer = teamManager.GetAllTeams().FirstOrDefault(t => t.Id == vm.TeamToRemovePlayer.Id);
            var team = teamManager.GetAllTeams().FirstOrDefault(t => t.Id == 0);
            team.Players.Clear();


            if (vm.PlayersToAdd != null && vm.PlayersToAdd.Count > 0)
            {
                foreach (var playerid in vm.PlayersToAdd)
                {
                    teamToRemovePlayer.Players.RemoveAll(p => p.Id == playerid);
                    team.Players.Add(playerManager.GetPlayerById(playerid));
                    var player = playerManager.GetPlayerById(playerid);
                    player.TeamId = team.Id;
                }
            }

            return RedirectToAction("CutPlayerToFreeAgency");
        }

        [HttpGet]
        public ActionResult AddLeaguelessTeamtoLeague(int id)
        {
            var teamManager = new TeamManager();         
            var leagueManager = new LeagueManager();
            var vm = new AddNoLeagueTeamToLeagueVM();
            vm.LeagueToAddTeam = leagueManager.GetLeagueById(id);
            vm.LeagueToRemoveTeam = leagueManager.GetLeagueById(0);
            var teams1 = teamManager.GetAllTeams().FindAll(t => t.LeagueId == 0);
            teams1.RemoveAll(t => t.Id == 0);
            var teams2 = teamManager.GetAllTeams().FindAll(t => t.LeagueId == id);
            vm.SetLeaguelessTeams(teams1);
            vm.SetTeamsInLeague(teams2);
            return View(vm);
        }

        [HttpPost]
        public ActionResult AddLeaguelessTeamtoLeague(AddNoLeagueTeamToLeagueVM vm)
        {
            var teamManager = new TeamManager();
           
            if (vm.TeamsToAdd != null && vm.TeamsToAdd.Count > 0)
            {
                foreach (var teamid in vm.TeamsToAdd)
                {
                    var team = teamManager.GetTeamById(teamid);
                    team.LeagueId = vm.LeagueToAddTeam.Id;
                }
            }
            return RedirectToAction("AddLeaguelessTeamtoLeague");
        }

        [HttpGet]
        public ActionResult RemoveTeamToLeagueless(int id)
        {
            var teamManager = new TeamManager();
            var leagueManager = new LeagueManager();
            var vm = new RemoveTeamToNoLeagueVM();
            vm.Leagueless = leagueManager.GetLeagueById(0);
            vm.LeagueToRemoveTeam = leagueManager.GetLeagueById(id);
            var teams1 = teamManager.GetAllTeams().FindAll(t => t.LeagueId == 0);
            teams1.RemoveAll(t => t.Id == 0);
            var teams2 = teamManager.GetAllTeams().FindAll(t => t.LeagueId == id); 
            vm.SetLeaguelessTeams(teams1);
            vm.SetTeamsInLeague(teams2);
            return View(vm);
        }


        [HttpPost]
        public ActionResult RemoveTeamToLeagueless(RemoveTeamToNoLeagueVM vm)
        {
            var teamManager = new TeamManager();

            if (vm.TeamsToAdd != null && vm.TeamsToAdd.Count > 0)
            {
                foreach (var teamid in vm.TeamsToAdd)
                {
                    var team = teamManager.GetTeamById(teamid);
                    team.LeagueId = vm.Leagueless.Id;
                }
            }
            return RedirectToAction("RemoveTeamToLeagueless");
        }

        [HttpGet]
        public ActionResult GetTeamsToTrade()
        {
            var teamManager = new TeamManager();
            var vm = new GetTeamsForTradeVM();
            var teams = teamManager.GetAllTeams().ToList();
            teams.RemoveAll(t => t.Players == null || t.Players.Count == 0);
            teams.RemoveAll(t => t.Id == 0);
            vm.SetTeam1List(teams);
            vm.SetTeam2List(teams);
            return View(vm);
        }

        [HttpPost]
        public ActionResult GetTeamsToTrade(GetTeamsForTradeVM vm)
        {
            var teamManager = new TeamManager();
            var playerManager = new PlayerManager();
            var newvm = new TradeVM();
            newvm.Team1 = teamManager.GetTeamById(vm.Team1ID);
            newvm.Team2 = teamManager.GetTeamById(vm.Team2ID);
            var team1players = playerManager.GetAllPlayers().FindAll(p => p.TeamId == newvm.Team1.Id);
            var team2players = playerManager.GetAllPlayers().FindAll(p => p.TeamId == newvm.Team2.Id);
            newvm.SetTeam1List(team1players);
            newvm.SetTeam2List(team2players);
            return View("TradePlayers", newvm);
        }

        [HttpPost]
        public ActionResult TradePlayers(TradeVM newvm)
        {
            var teamManager = new TeamManager();
            var playerManager = new PlayerManager();
            newvm.Team1 = teamManager.GetTeamById(newvm.Team1.Id);
            newvm.Team2 = teamManager.GetTeamById(newvm.Team2.Id);
            newvm.Team1.Players.Clear();
            newvm.Team2.Players.Clear();

            if (newvm.Team1PlayersToAdd != null && newvm.Team1PlayersToAdd.Count > 0)
            {
                foreach (var playerid in newvm.Team1PlayersToAdd)
                {
                    newvm.Team1.Players.RemoveAll(p => p.Id == playerid);
                    newvm.Team2.Players.Add(playerManager.GetPlayerById(playerid));
                    var player = playerManager.GetPlayerById(playerid);
                    player.TeamId = newvm.Team2.Id;
                }
            }
            if (newvm.Team2PlayersToAdd != null && newvm.Team2PlayersToAdd.Count > 0)
            {
                foreach (var playerid in newvm.Team2PlayersToAdd)
                {
                    newvm.Team2.Players.RemoveAll(p => p.Id == playerid);
                    newvm.Team1.Players.Add(playerManager.GetPlayerById(playerid));
                    var player = playerManager.GetPlayerById(playerid);
                    player.TeamId = newvm.Team1.Id;
                }
            }

            return RedirectToAction("Teams");
        }
    }
}