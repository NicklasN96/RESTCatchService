using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<Catch> cList = GetCustomersAsync().Result;
            Console.WriteLine(string.Join("\n", cList.ToString()));
            //Fast write out
            for (int i = 0; i < cList.Count; i++)
                Console.WriteLine(cList[i].ToString());
            Console.WriteLine();
        }

        private const string CatchUri = "http://localhost:60452/Service1.svc/catch/";

        public static async Task<IList<Catch>> GetCustomersAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(CatchUri);
                IList<Catch> cList = JsonConvert.DeserializeObject<IList<Catch>>(content);
                return cList;
            }
        }
    }

}
