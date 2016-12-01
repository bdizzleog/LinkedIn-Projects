using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Baseball.Models.ViewModels
{
    public class TradeVM
    {
        public Team Team1 { get; set; }
        public Team Team2 { get; set; }
        public List<SelectListItem> Team1Players { get; set; }
        public List<SelectListItem> Team2Players { get; set; }
        public List<int> Team1PlayersToAdd { get; set; }
        public List<int> Team2PlayersToAdd { get; set; }

        public void SetTeam1List(List<Player> players)
        {
            Team1Players = ConvertPlayerToSelectListItem(players);
        }

        public void SetTeam2List(List<Player> players)
        {
            Team2Players = ConvertPlayerToSelectListItem(players);
        }

        private List<SelectListItem> ConvertPlayerToSelectListItem(List<Player> players)
        {
            var newCollection = new List<SelectListItem>();

            if (players == null)
            {
                return new List<SelectListItem>();
            }

            {
                foreach (var player in players)
                {
                    newCollection.Add(new SelectListItem()
                    {
                        Text = player.JerseyNumber + " " + player.LastName + "," + player.FirstName,
                        Value = player.Id.ToString()
                    });
                }

            }
            return newCollection;
        }


    }


}
