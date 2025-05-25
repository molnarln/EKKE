using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaztartasiGepek
{
    public abstract class Nagygep : ICloneable, IComparable
    {
        protected Nagygep(string gyarto, string tipus)
        {
            Gyarto = new Gyarto(gyarto);
            Tipus = tipus ?? throw new ArgumentNullException(nameof(tipus));
        }

        public abstract int Relevancia { get; }

        public abstract double Hatekonysag();

        public Gyarto Gyarto { get; set; }
        public string Tipus { get; private set; }

        public override string ToString()
        {
            return $"{Gyarto} {Tipus}, {Relevancia}, {Hatekonysag() * 100}%";
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (obj == this) return true;
            if (!(obj is Nagygep)) return false;

            Nagygep masik = obj as Nagygep;
            return masik.Gyarto == this.Gyarto && masik.Tipus == this.Tipus;
        }

        public abstract object Clone();

        public int CompareTo(object obj)
        {
            if (!(obj is Nagygep)) throw new Exception("Típus nem megfelelő!");
            if (this == obj) return 0;
            Nagygep masik = obj as Nagygep;

            if (this.Relevancia > masik.Relevancia) return 1;
            if (this.Relevancia < masik.Relevancia) return -1;
            else return 0;

        }
    }
}
