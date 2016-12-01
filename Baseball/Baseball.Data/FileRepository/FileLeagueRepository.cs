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
    public class FileLeagueRepository : ILeagueRepository
    {
        private string _fileName;
        private static List<League> _leagues;

        public FileLeagueRepository()
        {
            if (HttpContext.Current == null)
            {
                new DataLogger("not on a server?", LogMessage.Error);
                return;
            }

            _fileName = HttpContext.Current.Server.MapPath("~/" + "Data/Leagues.json");

            if (_leagues == null)
            {
                var jss = new JavaScriptSerializer();
                _leagues = new List<League>();

                using (var r = new StreamReader(_fileName))
                {
                    var json = r.ReadToEnd();
                    _leagues = jss.Deserialize<List<League>>(json);
                }
            }

        }


        /// <summary>
        /// will add the league to the repository from the league that is passed in 
        /// </summary>
        /// <param name="league"></param>
        public void AddLeague(League league)
        {
            _leagues.Add(league);
            WriteFile();
        }


        /// <summary>
        /// will edit a league taht is passed in and allow them to change the other properties
        /// </summary>
        /// <param name="league"></param>
        public void EditLeague(League league)
        {
            var selectedLeague = _leagues.FirstOrDefault(l => l.Id == league.Id);
            selectedLeague.Name = league.Name;
            WriteFile();
        }


        /// <summary>
        /// lists all the leagues currently in the repo
        /// </summary>
        /// <returns></returns>
        public List<League> GetAllLeagues()
        {
            return _leagues;
        }


        /// <summary>
        /// will remove a league when the manager calls it according to id #'s matching the parameter
        /// </summary>
        /// <param name="id"></param>
        public void RemoveLeagueById(int id)
        {
            _leagues.RemoveAll(l => l.Id == id);
            WriteFile();
        }

        /// <summary>
        /// writing file to JSON when factory is called for file "not an interface method"
        /// </summary>
        private void WriteFile()
        {
            var json = new JavaScriptSerializer().Serialize(_leagues);
            File.WriteAllText(_fileName, json);
        }
    }
}
