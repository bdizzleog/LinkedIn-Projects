using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.AccessControl;
using System.Web.Http;
using Baseball.Bll.Managers;
using Baseball.Models;

namespace Baseball.Web.Controllers
{
    public class PlayersController : ApiController
    {
        public List<Player> Get()
        {
            var repo = new PlayerManager();
            return repo.GetAllPlayers();
        }

        public Player Get(int id)
        {
            var repo = new PlayerManager();
            return repo.GetPlayerById(id);
        }

        public HttpResponseMessage Post(Player newPlayer)
        {
            var repo = new PlayerManager();
            repo.AddPlayerToRepo(newPlayer);

            var response = Request.CreateResponse(HttpStatusCode.Created, newPlayer);

            string uri = Url.Link("DefaultApi", new {id = newPlayer.Id});
            response.Headers.Location = new Uri(uri);

            return response;
        }
    }
}
