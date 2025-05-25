using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaztartasiGepek
{
    public class Gyarto : ICloneable
    {
        public Gyarto(string nev)
        {
            Nev = nev ?? throw new ArgumentNullException(nameof(nev));
        }

        private Gyarto(string nev, bool nepszeru)
        {
            Nev = nev ?? throw new ArgumentNullException(nameof(nev));
            Nepszeru = nepszeru;
        }

        public string Nev { get; set; }
        private bool nepszeru;
        public bool Nepszeru
        {
            get
            {
                if (!GYARTOK.Any(_ => _.Nev == this.Nev)) throw new GyartoNemTalalhatoException(new Gyarto(Nev));
                return true;
            }
            private set { nepszeru = value; }
        }

        private static List<Gyarto> GYARTOK = new List<Gyarto>()
        {
            new Gyarto("Philips", true),
            new Gyarto("AEG", true),
            new Gyarto("Candy", false),
            new Gyarto("LG", true),
            new Gyarto("Phicolo", false),
            new Gyarto("Electrolux", true),
            new Gyarto("Beko", false)
        };

        public override string ToString()
        {
            return Nev;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
