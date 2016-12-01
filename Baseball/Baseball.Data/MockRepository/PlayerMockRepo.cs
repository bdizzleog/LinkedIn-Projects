using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baseball.Data.Interfaces;
using Baseball.Models;

namespace Baseball.Data.MockRepository
{
    class PlayerMockRepo : IPlayerRepository
    {
        private static List<Player> _players;

        public PlayerMockRepo()
        {
            if (_players == null)
            {
                _players = new List<Player>()
                {
                    new Player()
                    {
                        Id = 1,
                        FirstName = "Michael",
                        LastName = "Martinez",
                        JerseyNumber = 1,
                        Position = Positions.SB,
                        YearsPlayed = 7,
                        TeamId = 1,
                        BattingAvg = .301
                    },
                    new Player()
                    {
                    Id = 2,
                    FirstName = "Francisco",
                    LastName = "Lindor",
                    JerseyNumber = 12,
                    Position = Positions.SS,
                    YearsPlayed = 5,
                    TeamId = 1,
                    BattingAvg = .289
                },

                new Player()
                {
                    Id = 3,
                    FirstName = "Mike",
                    LastName = "Napoli",
                    JerseyNumber = 26,
                    Position = Positions.FB,
                    YearsPlayed = 7,
                    TeamId = 1,
                    BattingAvg = .198
                },
                new Player()
                {
                    Id = 4,
                    FirstName = "John",
                    LastName = "Jones",
                    JerseyNumber = 17,
                    Position = Positions.C,
                    YearsPlayed = 6,
                    TeamId = 2,
                    BattingAvg = .235
                },
                new Player()
                {
                    Id = 5,
                    FirstName = "Clark",
                    LastName = "Kent",
                    JerseyNumber = 52,
                    Position = Positions.TB,
                    YearsPlayed = 10,
                    TeamId = 2,
                    BattingAvg = .362
                },
                new Player()
                {
                    Id = 6,
                    FirstName = "Bruce",
                    LastName = "Wayne",
                    JerseyNumber = 33,
                    Position = Positions.CF,
                    YearsPlayed = 9,
                    TeamId = 2,
                    BattingAvg = .275
                },
                new Player()
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
                        }
                };
            }
        }
        public List<Player> GetAllPlayers()
        {
            return _players;
        }

        public void AddPlayer(Player player)
        {
            _players.Add(player);
        }

        public void EditPlayer(Player player)
        {
            var selectedPlayer = _players.FirstOrDefault(p => p.Id == player.Id);
            selectedPlayer.BattingAvg = player.BattingAvg;
            selectedPlayer.JerseyNumber = player.JerseyNumber;
            selectedPlayer.FirstName = player.FirstName;
            selectedPlayer.LastName = player.LastName;
            selectedPlayer.Position = player.Position;        
            selectedPlayer.YearsPlayed = player.YearsPlayed;
        }

        public void RemovePlayerById(int id)
        {
            _players.RemoveAll(p => p.Id == id);
        }

        public Player Get(int id)
        {
            return _players.FirstOrDefault(p => p.Id == id);
        }
    }
}