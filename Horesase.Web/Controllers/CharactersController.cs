using Horesase.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Horesase.Web.Controllers
{
    public class CharactersController : ApiController
    {
        public IEnumerable<Character> Get()
        {
            return MeigenContext.Characters;
        }
    }
}
