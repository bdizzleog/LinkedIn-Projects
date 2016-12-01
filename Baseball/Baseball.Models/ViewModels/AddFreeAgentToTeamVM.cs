using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Baseball.Models.ViewModels
{
    public class AddFreeAgentToTeamVM
    {
        public Team TeamToAddPlayer { get; set; }
        public Team TeamToRemovePlayer { get; set; }
        public List<SelectListItem> FreeAgencyPlayers { get; set; }
        public List<SelectListItem> PlayersOnTeam { get; set; }
        public List<int> PlayersToAdd { get; set; }

        public void SetPlayerList(List<Player> players)
        {
            FreeAgencyPlayers = ConvertPlayerToSelectListItem(players);
        }

        public void SetTeamRoster(List<Player> players)
        {
            PlayersOnTeam = ConvertPlayerToSelectListItem(players);
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
