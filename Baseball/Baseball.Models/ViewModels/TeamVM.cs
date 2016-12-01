using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Baseball.Models.ViewModels
{
    public class TeamVM
    {
        public Team Team { get; set; }
        public League TeamLeague { get; set; }
        public Team FreeAgents { get; set; }       
    }
}
