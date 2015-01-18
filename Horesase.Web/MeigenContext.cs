using Horesase.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Horesase.Web
{
    public static class MeigenContext
    {
        private static IEnumerable<Meigen> meigens;
        private static IEnumerable<Character> characters;

        public async static Task Initialize(string jsonPath)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(jsonPath);
                var json = await response.Content.ReadAsStringAsync();
                meigens = JsonConvert.DeserializeObject<IEnumerable<Meigen>>(json);
                characters = meigens.GroupBy(m => m.character)
                    .Select(item => new Character(){ name = item.Key, count = item.Count()}).ToArray();
            }
        }

        public static IEnumerable<Meigen> Meigens {get {return meigens;}}
        public static IEnumerable<Character> Characters { get { return characters; } }

    }
}