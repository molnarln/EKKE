using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaztartasiGepek
{
    public class MaximalisFordulatszamNemErvenyesException : Exception
    {
        public string Gyarto { get; set; }
        public string  Tipus { get; set; }
        public int MaxToltoTomeg { get; set; }
        public int Ervenytelenfordulatszam { get; set; }

        public MaximalisFordulatszamNemErvenyesException(string gyarto, string tipus, int maxToltoTomeg, int ervenytelenFordulatszam)
        {
            Gyarto = gyarto;
            Tipus = tipus;
            MaxToltoTomeg = maxToltoTomeg;
            Ervenytelenfordulatszam = ervenytelenFordulatszam;
        }
    }
}
