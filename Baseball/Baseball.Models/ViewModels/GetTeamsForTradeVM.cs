using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Baseball.Models.ViewModels
{
    public class GetTeamsForTradeVM
    {
        public int Team1ID { get; set; }
        public int Team2ID { get; set; }       
        public List<SelectListItem> Team1Choice { get; set; }
        public List<SelectListItem> Team2Choice { get; set; }

        public void SetTeam1List(List<Team> teams)
        {
            Team1Choice = ConvertTeamsToSelectListItem(teams);
        }

        public void SetTeam2List(List<Team> teams)
        {
            Team2Choice = ConvertTeamsToSelectListItem(teams);
        }

        private List<SelectListItem> ConvertTeamsToSelectListItem(List<Team> teams)
        {
            var newCollection = new List<SelectListItem>();

            if (teams == null)
            {
                return new List<SelectListItem>();
            }

            {
                foreach (var team in teams)
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
