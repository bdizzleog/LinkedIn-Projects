using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using Baseball.Data.FileRepository;
using Baseball.Data.Interfaces;
using Baseball.Data.MockRepository;

namespace Baseball.Data
{
    public class Factory
    {
        private string _mode;

        public Factory()
        {
           _mode = WebConfigurationManager.AppSettings["Mode"].ToUpper();
        }

        public IPlayerRepository PlayerRepository()
        {
            switch (_mode)
            {
                case "FILE":
                    return new FilePlayerRepository();
                case "MOCK":
                    return new PlayerMockRepo();
                case "DB":
                    throw new NotSupportedException();
                default:
                    throw new NotSupportedException();
            }           
        }

        public ITeamRepository TeamRepository()
        {
            switch (_mode)
            {
                case "FILE":
                    return new FileTeamRepository();
                case "MOCK":
                    return new MockTeamRepository();
                case "DB":
                    throw new NotSupportedException();
                default:
                    throw new NotSupportedException();
            }
        }

        public ILeagueRepository LeagueRepository()
        {
            switch (_mode)
            {
                case "FILE":
                    return new FileLeagueRepository();
                case "MOCK":
                    return new MockLeagueRepository();
                case "DB":
                    throw new NotSupportedException();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
