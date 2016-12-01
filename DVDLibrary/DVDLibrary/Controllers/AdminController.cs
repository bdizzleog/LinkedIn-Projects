using DVDLibrary.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using DVDLibrary.Models;
using DVDLibrary.Models.Enums;

namespace DVDLibrary.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CheckOutDVD(int id)
        {
            var manager = new Manager();
            var dvd = manager.GetDVDById(id);

            return View(dvd);
        }


        [HttpPost]
        public ActionResult CheckOutDVD(DVD dvd)
        {
            var manager = new Manager();
            
            dvd.CheckOutDate = DateTime.Now;
            dvd.Status = LendingStatus.CheckedOut;
            dvd.Borrower = new Borrower();
            manager.CheckOutDVD(dvd);

            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public ActionResult AddDVD()
        {
            return View(new DVD());
        }

        [HttpPost]
        public ActionResult AddDVD(DVD dvd)
        {
            var manager = new Manager();
            manager.AddDVD(dvd);
            dvd.CheckOutDate = DateTime.Now;
            dvd.Status = LendingStatus.CheckedOut;
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult ReturnDVD(int id)
        {
            var manager = new Manager();
            var dvd = manager.GetDVDById(id);

            return View(dvd);
        }

        [HttpPost]
        public ActionResult ReturnDVD(DVD dvd)
        {
            var manager = new Manager();
            dvd.ReturnDate = DateTime.Now;
            dvd.Status = LendingStatus.InStock;
            
            manager.ReturnDVD(dvd);
            
            
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult DeleteDVD(int id)
        {
            var manager = new Manager();
            var dvd = manager.GetDVDById(id);

            return View(dvd);
        }

        [HttpPost]
        public ActionResult DeleteDVD(DVD dvd)
        {
            var manager = new Manager();
            manager.DeleteDVD(dvd.Id);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult SearchDVD(string searchInput)
        {
            if (searchInput != null)
            {
                var manager = new Manager();
                var dvd = manager.GetDVDByName(searchInput.ToLower());

                return View(dvd);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}