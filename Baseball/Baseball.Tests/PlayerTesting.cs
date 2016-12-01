using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Baseball.Bll.Managers;
using Baseball.Models;
using NUnit.Framework;

namespace Baseball.Tests
{
    [TestFixture]
    class PlayerTesting
    {
        [Test]
        public void AddPlayerTest()
        {

            var manager = new PlayerManager();

            var _players = manager.GetAllPlayers();

            int count = _players.Count();

            var player = new Player
            {
                FirstName = "Ryan",
                LastName = "Rowe",
                JerseyNumber = 33,
                Position = Positions.P,
                BattingAvg = .500,
                YearsPlayed = 5,
                TeamId = 0,
                LeagueId = 0
            };

            manager.AddPlayerToRepo(player);

            bool result = (_players.Count() == count + 1);

            Assert.IsTrue(result);

            foreach (var p in _players)
            {
                Console.WriteLine($"{p.Id},{p.FirstName},{p.LastName},{p.Position}");
            }
        }

        [Test]
        public void DeletePlayerTest()
        {
            var manager = new PlayerManager();
            var _players = manager.GetAllPlayers();
            int count = _players.Count();
            var player2 = _players.FirstOrDefault(p => p.Id == 2);
            var player3 = _players.FirstOrDefault(p => p.Id == 3);
            manager.RemovePlayerById(player2.Id);
            manager.RemovePlayerById(player3.Id);


            bool result = (_players.Count == count - 2);

            Assert.IsTrue(result);

            foreach (var p in _players)
            {
                Console.WriteLine($"{p.Id}, {p.FirstName}, {p.LastName}, {p.Position}");
            }


        }




    }
}
