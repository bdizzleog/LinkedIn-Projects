using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using Baseball.Data.Interfaces;
using Baseball.Models;
using Baseball.Models.Enums;

namespace Baseball.Data.FileRepository
{
    public class FilePlayerRepository : IPlayerRepository
    {

        private string _fileName;
        private static List<Player> _players;

        public FilePlayerRepository()
        {
            if (HttpContext.Current == null)
            {
                new DataLogger("not on a server?", LogMessage.Error);
                return;
            }

            _fileName = HttpContext.Current.Server.MapPath("~/" + "Data/Players.json");

            if (_players == null)
            {
                var jss = new JavaScriptSerializer();
                _players = new List<Player>();

                using (var r = new StreamReader(_fileName))
                {
                    var json = r.ReadToEnd();
                    _players = jss.Deserialize<List<Player>>(json);
                }
            }

        }

        public List<Player> GetAllPlayers()
        {
            return _players;
        }

        public void AddPlayer(Player player)
        {
            _players.Add(player);
            WriteFile();
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
            WriteFile();
        }

        public void RemovePlayerById(int id)
        {
            _players.RemoveAll(p => p.Id == id);
            WriteFile();
        }

        private void WriteFile()
        {
            var json = new JavaScriptSerializer().Serialize(_players);
            File.WriteAllText(_fileName, json);
        }      
    }
}