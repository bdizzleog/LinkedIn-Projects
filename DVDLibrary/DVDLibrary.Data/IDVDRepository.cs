using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Models;

namespace DVDLibrary.Data
{
    public interface IDVDRepository
    {
        List<DVD> GetAllDVDs();
        void AddDVD(DVD dvd);
        void EditDVD(DVD dvd);
        void DeleteDVD(int id);
        void CheckOutDVD(DVD dvd);
        void ReturnDVD(DVD dvd);
    }
}
