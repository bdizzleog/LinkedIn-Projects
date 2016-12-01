using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.BLL;
using DVDLibrary.Models;
using DVDLibrary.Models.Enums;
using NUnit.Framework;

namespace DVDLibrary.Test
{
    [TestFixture]
    class DVDTest
    {

        [Test]
        public void AddDVDTest()
        {
            var manager = new Manager();

            var _dvds = manager.GetAllDVDs();

            int count = _dvds.Count();

            var dvd = new DVD
            {

                Title = "Test",
                Director = "Test",
                Studio = "Test",
                Rating = MPAARating.NR,
                Status = LendingStatus.InStock,
                //Genre = Genres.Action,
                UserRating = 4,
                //ReleaseDate = DateTime.Parse("10-10-2010"),
                Actors =
                {

                },


            };

            manager.AddDVD(dvd);

            bool result = (_dvds.Count() == count + 1);

            Assert.IsTrue(result);
        }

        [Test]
        public void DeleteDVDTest()
        {
            var manager = new Manager();
            var _dvds = manager.GetAllDVDs();
            int count = _dvds.Count();
            var dvd1 = _dvds.FirstOrDefault(d => d.Id == 1);
            var dvd2 = _dvds.FirstOrDefault(d => d.Id == 2);
            manager.DeleteDVD(dvd2.Id);
            manager.DeleteDVD(dvd1.Id);

            bool result = (_dvds.Count == count - 2);

            Assert.IsTrue(result);
        }
    }

    
}
