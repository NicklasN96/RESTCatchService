using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Catch
    {
        public int id { get; set; }

        public string navn { get; set; }

        public string art { get; set; }

        public double vaegt { get; set; }

        public string sted { get; set; }

        public int uge { get; set; }

        public Catch(int id, string navn, string art, double vaegt, string sted, int uge)
        {
            this.id = id;
            this.navn = navn;
            this.art = art;
            this.vaegt = vaegt;
            this.sted = sted;
            this.uge = uge;
        }

        public Catch()
        {

        }
    }
}
