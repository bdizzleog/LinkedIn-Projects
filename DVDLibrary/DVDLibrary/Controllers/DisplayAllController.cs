using DVDLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DVDLibrary.Models.Enums;
using DVDLibrary.BLL;

namespace DVDLibrary.Controllers
{
    public class DisplayAllController : ApiController
    {
        public List<DVD> Get()
        {
            var manager = new Manager();
            
            return manager.GetAllDVDs();
            
        }

        public DVD Get(int id)
        {
            var manager = new Manager();
            return manager.GetDVDById(id);
        }
    }
}
