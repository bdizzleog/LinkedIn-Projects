using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baseball.Bll.Managers;
using Baseball.Data;
using Baseball.Models;
using NUnit.Framework;

namespace Baseball.Tests
{
    [TestFixture]
    public class TeamTesting
    {
        TeamManager manager = new TeamManager();

        [Test]
        public void AddTeamTest()
        {           
            var teamToAdd = new Team()
            {
                Name = "Dallas Cowboys",
                Manager = "Ryan Rowe",
                LeagueId = 0,
                Players = new List<Player>
                {
                    new Player
                    {
                        Id = 10,
                        FirstName = "Jason",
                        LastName = "Bekkel",
                        BattingAvg = .235,
                        JerseyNumber = 17,
                        Position = Positions.C,
                        YearsPlayed = 6,
                        TeamId = 2
                    },
                    new Player
                    {
                        Id = 11,
                        FirstName = "Randal",
                        LastName = "Randelic",
                        BattingAvg = .382,
                        JerseyNumber = 52,
                        Position = Positions.TB,
                        YearsPlayed = 10,
                        TeamId = 2
                    },
                    new Player
                    {
                        Id = 12,
                        FirstName = "Dak",
                        LastName = "Prescott",
                        BattingAvg = .275,
                        JerseyNumber = 33,
                        Position = Positions.CF,
                        YearsPlayed = 9,
                        TeamId = 2,
                    }

                }
            };

            manager.AddTeam(teamToAdd);

            var _teams = manager.GetAllTeams();

            foreach (var t in _teams)
            {
                Console.WriteLine($"{t.Id}, {t.Name}, {t.Manager}");

                foreach (var p in t.Players)
                {
                    Console.WriteLine($"{p.Id}, {p.FirstName}, {p.LastName}");
                }
            }
        }

        [Test]
        public void DeleteTeamTest()
        {
            var _teams = manager.GetAllTeams();

            var teamToDelete = _teams.FirstOrDefault(t => t.Id == 1);

            var team = manager.GetTeamById(teamToDelete.Id);

            manager.DeleteTeam(team.Id);

            var freeAgency = _teams.FirstOrDefault(t => t.Id == 0);

            foreach (var player in freeAgency.Players)
            {
                Console.WriteLine($"Team Id {player.TeamId}, Player Id {player.Id}, FN {player.FirstName}, LN {player.LastName}");
            }
         
            foreach (var t in _teams)
            {
                Console.WriteLine($"{t.Id}, {t.Manager}, {t.Name}");
            }


        }
    }
}