using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Baseball.Bll.Managers;
using Baseball.Models;
using Baseball.Models.ViewModels;

namespace Baseball.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var vm = new HomeIndexVm();
            vm.Leagues = new LeagueManager().GetAllLeagues().OrderBy(l => l.Name).ToList();
            vm.Teams = new TeamManager().GetAllTeams().OrderBy(t => t.Name).ToList();

            return View(vm);
        }
    }
}