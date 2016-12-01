using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Data;
using DVDLibrary.Models;

namespace DVDLibrary.BLL
{
    public class Manager
    {
        private static IDVDRepository _dvdRepo;

        public Manager()
        {
            _dvdRepo = new Factory().DVDRepository();
        }

        public List<DVD> GetAllDVDs()
        {
            return _dvdRepo.GetAllDVDs();
        }

        public void AddDVD(DVD dvd)
        {
            if (GetAllDVDs().Count != 0)
            {
                dvd.Id = GetAllDVDs().LastOrDefault().Id + 1;
            }
            else
            {
                dvd.Id = 1;
            }
            _dvdRepo.AddDVD(dvd);
        }

        public void EditDVD(DVD dvd)
        {
            _dvdRepo.EditDVD(dvd);

        }

        public void DeleteDVD(int id)
        {
            var dvd = _dvdRepo.GetAllDVDs().FirstOrDefault(d => d.Id == id);
            _dvdRepo.DeleteDVD(dvd.Id);
        }

        public DVD GetDVDById(int id)
        {
            return GetAllDVDs().FirstOrDefault(d => d.Id == id);
        }

        public IEnumerable<DVD> GetDVDByName(string searchInput)
        {
            // CaSe insensitive!
            if (!string.IsNullOrEmpty(searchInput))
            {
                var movies = _dvdRepo.GetAllDVDs().Where(m => m.Title.ToLower().Contains(searchInput));
                if (movies.Any())
                {
                    return movies;
                }
            }

            return null;
        }

        public void CheckOutDVD(DVD dvd)
        {
            _dvdRepo.CheckOutDVD(dvd);
        }

        public void ReturnDVD(DVD dvd)
        {
            _dvdRepo.ReturnDVD(dvd);
        }
    }
}