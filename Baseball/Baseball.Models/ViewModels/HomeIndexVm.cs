using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baseball.Models.ViewModels
{
    public class HomeIndexVm
    {
        public List<Team> Teams { get; set; }
        public List<League> Leagues { get; set; }

        public HomeIndexVm()
        {
            Teams = new List<Team>();
            Leagues = new List<League>();
        }
    }
}
