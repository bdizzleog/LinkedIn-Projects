using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace DVDLibrary.Data
{
    public class Factory
    {
        private string _mode;

        public Factory()
        {
            _mode = WebConfigurationManager.AppSettings["Mode"].ToUpper();
        }

        public IDVDRepository DVDRepository()
        {
            switch (_mode)
            {
                //case "FILE":
                //    return new DVDFileRepository();
                case "MOCK":
                    return new DVDMockRepository();
                case "DB":
                    throw new NotSupportedException();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
