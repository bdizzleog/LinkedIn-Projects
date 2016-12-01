using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Baseball.Models.ViewModels
{
    public class LeagueVM
    {
        public League League { get; set; }
        public List<Team> TeamsInLeague { get; set; }   
    }

    
}
