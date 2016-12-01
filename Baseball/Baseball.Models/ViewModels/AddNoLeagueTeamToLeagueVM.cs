using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Baseball.Models.ViewModels
{
    public class AddNoLeagueTeamToLeagueVM
    {
        public League LeagueToAddTeam { get; set; }
        public League LeagueToRemoveTeam { get; set; }
        public List<SelectListItem> LeaguelessTeams { get; set; }
        public List<SelectListItem> TeamsOnLeague { get; set; }
        public List<int> TeamsToAdd { get; set; }

        public void SetLeaguelessTeams(List<Team> teams)
        {
            LeaguelessTeams = ConvertPlayerToSelectListItem(teams);
        }

        public void SetTeamsInLeague(List<Team> teams)
        {
            TeamsOnLeague = ConvertPlayerToSelectListItem(teams);
        }

        private List<SelectListItem> ConvertPlayerToSelectListItem(List<Team> teams)
        {
            var newCollection = new List<SelectListItem>();

            foreach (var team in teams)
            {
                if (team.Id != 0)
                {
                    newCollection.Add(new SelectListItem()
                    {
                        Text = team.Name,
                        Value = team.Id.ToString()
                    });
                }

            }
            return newCollection;

        }
    }
}
