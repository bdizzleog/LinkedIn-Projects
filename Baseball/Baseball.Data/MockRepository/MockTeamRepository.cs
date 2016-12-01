using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baseball.Data.Interfaces;
using Baseball.Models;

namespace Baseball.Data.MockRepository
{
    public class MockTeamRepository : ITeamRepository
    {
        private static List<Team> _teams;

        static MockTeamRepository()
        {
            _teams = new List<Team>()
            {
                new Team()
                {
                    Id = 0,
                    Name = "Free Agency",
                    Manager = "None",
                    LeagueId = 0,
                    Players = new List<Player>
                    {
                        new Player
                        {
                            Id = 7,
                            FirstName = "Michael",
                            LastName = "Money",
                            BattingAvg = .301,
                            JerseyNumber = 1,
                            Position = Positions.C,
                            YearsPlayed = 7,
                            TeamId = 0
                        },
                        new Player
                        {
                            Id = 8,
                            FirstName = "Victor",
                            LastName = "Pudelski",
                            BattingAvg = .289,
                            JerseyNumber = 12,
                            Position = Positions.SS,
                            YearsPlayed = 5,
                            TeamId = 0
                        },
                        new Player
                        {
                            Id = 9,
                            FirstName = "Christian",
                            LastName = "Springer",
                            BattingAvg = .198,
                            JerseyNumber = 26,
                            Position = Positions.FB,
                            YearsPlayed = 8,
                            TeamId = 0
                        },
                    }
                },
                new Team()
                {
                    Id = 1,
                    Name = "Cleveland Indians",
                    Manager = "Terry Francona",
                    LeagueId = 1,
                    Players = new List<Player>
                    {
                        new Player
                        {
                            Id = 1,
                            FirstName = "Michael",
                            LastName = "Martinez",
                            BattingAvg = .301,
                            JerseyNumber = 1,
                            Position = Positions.SB,
                            YearsPlayed = 7,
                            TeamId = 1
                        },
                        new Player
                        {
                            Id = 2,
                            FirstName = "Francisco",
                            LastName = "Lindor",
                            BattingAvg = .289,
                            JerseyNumber = 12,
                            Position = Positions.SS,
                            YearsPlayed = 5,
                            TeamId = 1
                        },
                        new Player
                        {
                            Id = 3,
                            FirstName = "Mike",
                            LastName = "Napoli",

                            BattingAvg = .198,
                            JerseyNumber = 26,
                            Position = Positions.FB,
                            YearsPlayed = 8,
                            TeamId = 1
                        },
                    }
                },
                new Team()
                {
                    Id = 2,
                    Name = "Chicago Cubs",
                    Manager = "Joe Maddon",
                    LeagueId = 2,
                    Players = new List<Player>
                    {
                        new Player
                        {
                            Id = 4,
                            FirstName = "John",
                            LastName = "Jones",
                            BattingAvg = .235,
                            JerseyNumber = 17,
                            Position = Positions.C,
                            YearsPlayed = 6,
                            TeamId = 2
                        },
                        new Player
                        {
                            Id = 5,
                            FirstName = "Clark",
                            LastName = "Kent",
                            BattingAvg = .382,
                            JerseyNumber = 52,
                            Position = Positions.TB,
                            YearsPlayed = 10,
                            TeamId = 2
                        },
                        new Player
                        {
                            Id = 6,
                            FirstName = "Bruce",
                            LastName = "Wayne",
                            BattingAvg = .275,
                            JerseyNumber = 33,
                            Position = Positions.CF,
                            YearsPlayed = 9,
                            TeamId = 2,
                        },

                    }

                },
                  new Team()
                {
                    Id = 3,
                    Name = "New York Yankees",
                    Manager = "Ryan Rowe",
                    LeagueId = 0,
                    Players = new List<Player>
                    {
                        new Player
                        {
                            Id = 10,
                            FirstName = "Dak",
                            LastName = "Prescottish",
                            BattingAvg = .999,
                            JerseyNumber = 9,
                            Position = Positions.LF,
                            YearsPlayed = 7,
                            TeamId = 3
                        },
                        new Player
                        {
                            Id = 11,
                            FirstName = "Eric",
                            LastName = "VonWardington",
                            BattingAvg = .289,
                            JerseyNumber = 44,
                            Position = Positions.SB,
                            YearsPlayed = 99,
                            TeamId = 3
                        },
                        new Player
                        {
                            Id = 12,
                            FirstName = "Ben",
                            LastName = "Kraus",
                            BattingAvg = .444,
                            JerseyNumber = 88,
                            Position = Positions.CF,
                            YearsPlayed = 22,
                            TeamId = 3
                        },
                    }
                }

            };
        }

        public void AddTeam(Team team)
        {
            _teams.Add(team);
        }

        public void DeleteTeam(int id)
        {
            _teams.RemoveAll(t => t.Id == id);
        }

        public void EditTeam(Team team)
        {  
            var selectedTeam = _teams.FirstOrDefault(t => t.Id == team.Id);
            selectedTeam.Name = team.Name;
            //selectedTeam.LeagueId = team.LeagueId; taking this and Players below out seemed to work and changed the controller and they keep they re old props
            selectedTeam.Manager = team.Manager;
           // selectedTeam.Players = team.Players;
        }

        public Team Get(int id)
        {

            return _teams.FirstOrDefault(t => t.Id == id);

        }

        public List<Team> GetAllTeams()
        {
            return _teams;
        }

        
    }
}

