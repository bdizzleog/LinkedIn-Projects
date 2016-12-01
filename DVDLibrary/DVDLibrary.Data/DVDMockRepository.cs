using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Models;
using DVDLibrary.Models.Enums;

namespace DVDLibrary.Data
{
    class DVDMockRepository : IDVDRepository
    {
        private static List<DVD> _dvds;

        public DVDMockRepository()
        {
            if (_dvds == null)
            {
                _dvds = new List<DVD>()
                {
                    
                    new DVD()
                    {
                        Id = 1,
                        Title = "Full Metal Jacket",
                        Year = "1987",
                        Rating = MPAARating.R,
                        Released = DateTime.Parse("10 Jul 1987"),
                        RunTime = "116 min",
                        Genre = "Drama, War",
                        Director = "Stanley Kubrick",
                        Writer = "Gustav Hasford (novel), Stanley Kubrick (screenplay), Michael Herr (screenplay), Gustav Hasford (screenplay)",
                        Actors = "Matthew Modine, Adam Baldwin, Vincent D'Onofrio, R. Lee Ermey",
                        Plot = "A two-segment look at the effect of the military mindset and war itself on Vietnam era Marines. The first half follows a group of recruits in boot camp under the command of the punishing Gunnery Sergeant Hartman. The second half shows one of those recruits, Joker, covering the war as a correspondent for Stars and Stripes, focusing on the Tet offensive.",
                        Language = "English, Vietnamese",
                        Awards = "Nominated for 1 Oscar. Another 7 wins & 9 nominations.",
                        Poster = "https://images-na.ssl-images-amazon.com/images/M/MV5BMjA4NzY4ODk4Nl5BMl5BanBnXkFtZTgwOTcxNTYxMTE@._V1_SX300.jpg",
                        Metascore = 78,
                        ImdbRating = 8.3m,
                        ImdbId = "tt0093058",
                        Studio = "Warner Bros.",
                        UserRating = 10,
                        UserNotes = "Best Movie Ever",
//Borrower =
//                        {
//                        FirstName = "Dank",
//                        LastName = "Meme",
//                        PhoneNumber = "555-5555"
//                    }

                    }
                    
                };
            }
        }

        public List<DVD> GetAllDVDs()
        {
            return _dvds;
        }

        public void AddDVD(DVD dvd)
        {
            _dvds.Add(dvd);
        }

        public void EditDVD(DVD dvd)
        {
            var selectedDVD = _dvds.FirstOrDefault(d => d.Id == dvd.Id);
            selectedDVD.Id = dvd.Id;
            selectedDVD.Title = dvd.Title;
            selectedDVD.Director = dvd.Director;

            //selectedDVD.Genre = dvd.Genre;
            selectedDVD.Status = dvd.Status;
            selectedDVD.Borrower = dvd.Borrower;
            selectedDVD.CheckOutDate = dvd.CheckOutDate;
            selectedDVD.ReturnDate = dvd.ReturnDate;
            selectedDVD.UserNotes = dvd.UserNotes;


        }

        public void CheckOutDVD(DVD dvd)
        {
            var selectedDVD = _dvds.FirstOrDefault(d => d.Id == dvd.Id);
            
            selectedDVD.Id = dvd.Id;
            selectedDVD.CheckOutDate = dvd.CheckOutDate;
            selectedDVD.Borrower = dvd.Borrower;
            selectedDVD.Status = dvd.Status;
            

        }

        public void ReturnDVD(DVD dvd)
        {
            var selectedDVD = _dvds.FirstOrDefault(d => d.Id == dvd.Id);
            
            selectedDVD.Id = dvd.Id;
            selectedDVD.ReturnDate = dvd.ReturnDate;
            selectedDVD.UserNotes = dvd.UserNotes;
            selectedDVD.Status = dvd.Status;
        }

        public void DeleteDVD(int id)
        {
            _dvds.RemoveAll(d => d.Id == id);
        }
    }
}
