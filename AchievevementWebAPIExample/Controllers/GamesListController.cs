using AchievevementWebAPIExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AchievevementWebAPIExample.Controllers
{
    public class GamesListController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public dynamic getGamesList()
        {
            return db.Games.ToList();
        }
    }
}
