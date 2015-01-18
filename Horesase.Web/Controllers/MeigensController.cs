using Horesase.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Horesase.Web.Controllers
{
    public class MeigensController : ApiController
    {
        public IEnumerable<Meigen> Get()
        {
            return MeigenContext.Meigens;
        }

        public Meigen Get(int id)
        {
            return MeigenContext.Meigens.FirstOrDefault(m => m.id == id);
        }

        public IEnumerable<Meigen> Get(string word)
        {
            if (word.IsNullOrWhitespace()) return Enumerable.Empty<Meigen>();
            return MeigenContext.Meigens.Where(m =>
            {
                return (!m.character.IsNullOrWhitespace() && m.character.Contains(word))
                || (!m.title.IsNullOrWhitespace() && m.title.Contains(word))
                || (!m.body.IsNullOrWhitespace() && m.body.Contains(word))
                ;
            });
        }
        
        public IEnumerable<Meigen> Get(string character, string word)
        {
            return MeigenContext.Meigens
                .Where(m => character.IsNullOrWhitespace() || (!m.character.IsNullOrWhitespace() && m.character.Contains(character)))
                .Where(m => word.IsNullOrWhitespace() || ((!m.title.IsNullOrWhitespace() && m.title.Contains(word)) || (!m.body.IsNullOrWhitespace() && m.body.Contains(word))));
        }

        public void Post(Meigen meigen)
        {
            //TODO DBにしたら対応する
            throw new NotImplementedException();
        }
    }
}
