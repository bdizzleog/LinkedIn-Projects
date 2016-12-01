using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baseball.Models;

namespace Baseball.Data.Interfaces
{
    public interface IPlayerRepository
    {
        List<Player> GetAllPlayers();
        void AddPlayer(Player player);
        void EditPlayer(Player player);
        void RemovePlayerById(int id);
       
    }
}
