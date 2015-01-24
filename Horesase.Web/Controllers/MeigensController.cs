using Horesase.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Horesase.Web.Controllers
{
    public class MeigensController : ApiController
    {
        /// <summary>
        /// meigens/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Meigen Get(int id)
        {
            return MeigenContext.Meigens.FirstOrDefault(m => m.id == id);
        }

        /// <summary>
        /// meigens
        /// </summary>
        /// <param name="word"></param>
        /// <param name="character"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public IEnumerable<Meigen> Get(string word = "", string character = "", int limit = 15, int offset = 0)
        {
            var query =
                MeigenContext.Meigens
                .Where(m => character.IsNullOrWhitespace() || (!m.character.IsNullOrWhitespace() && m.character.Contains(character)))
                .Where(m => word.IsNullOrWhitespace() || ((!m.title.IsNullOrWhitespace() && m.title.Contains(word)) || (!m.body.IsNullOrWhitespace() && m.body.Contains(word))));

            var totalCount = query.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / limit);

            HttpContext.Current.Response.Headers.Add(
                "X-Pagination",
                JsonConvert.SerializeObject(new
                {
                    total_count = totalCount,
                    total_pages = totalPages
                })
            );

            return query
                .Skip(limit * offset)
                .Take(limit);
        }


        public void Post(Meigen meigen)
        {
            //TODO DBにしたら対応する
            throw new NotImplementedException();
        }
    }
}
