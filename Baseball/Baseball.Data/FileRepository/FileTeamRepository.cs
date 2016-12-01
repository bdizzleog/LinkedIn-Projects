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
    public class FileTeamRepository : ITeamRepository

    {
        private string _fileName;
        private List<Team> _teams;

        public FileTeamRepository()
        {
            if (HttpContext.Current == null)
            {
                new DataLogger("not on a server?", LogMessage.Error);
                return;
            }

            _fileName = HttpContext.Current.Server.MapPath("~/" + "Data/Teams.json");
            
            if (_teams == null)
            {
                var jss = new JavaScriptSerializer();
                _teams = new List<Team>();

                using (var sr = new StreamReader(_fileName))
                {
                    var json = sr.ReadToEnd();
                    _teams = jss.Deserialize<List<Team>>(json);
                }
            }
        }
        public List<Team> GetAllTeams()
        {
            return _teams;
        }

        public void AddTeam(Team team)
        {
            _teams.Add(team);
            WriteFile();
        }

        public void DeleteTeam(int id)
        {
            _teams.RemoveAll(t => t.Id == id);
            WriteFile();
        }

        public void EditTeam(Team team)
        {
            var selectedTeam = _teams.FirstOrDefault(t => t.Id == team.Id);
            selectedTeam.Id = team.Id;
            selectedTeam.Name = team.Name;
           // selectedTeam.LeagueId = team.LeagueId;
            selectedTeam.Manager = team.Manager;
           // selectedTeam.Players = team.Players;
        }

        private void WriteFile()
        {
            var json = new JavaScriptSerializer().Serialize(_teams);
            File.WriteAllText(_fileName, json);
        }

        public Team Get(int id)
        {
            return _teams.FirstOrDefault(t => t.Id == id);

        }
    }
}