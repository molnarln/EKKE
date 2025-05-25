using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaztartasiGepek
{
    public class Mosogep : Nagygep, IMosogep
    {
        public override int Relevancia
        {
            get
            {
                return (int)((Hatekonysag() - 0.26) * 7.4);
            }
        }

        private int maxToltotomeg;
        public int MaxToltotomeg
        {
            get
            {
                return maxToltotomeg;
            }
            private set
            {
                if (value < 5) throw new Exception("Túl kicsi töltőtömeg.");
                if (value > 11) throw new NagyMaximalisToltotomegException();
                maxToltotomeg = value;
            }
        }

        private int maxFordulat;
        public int MaxFordulat
        {
            get { return maxFordulat; }
            private set
            {
                if (value % 100 > 0) throw new MaximalisFordulatszamNemErvenyesException(Gyarto.Nev, Tipus, MaxToltotomeg, value);
                if (value < 800 || value > 1400) throw new Exception("Nem érvényes fordulatszám");
                maxFordulat = value;
            }
        }

        public Mosogep(string gyarto, string tipus, int maxToltoTomeg, int maxFordulat) : base(gyarto, tipus)
        {
            MaxToltotomeg = maxToltoTomeg;
            MaxFordulat = maxFordulat;
        }

        public override object Clone()
        {
            return new Mosogep(this.Gyarto.Nev, this.Tipus, this.MaxToltotomeg, this.MaxFordulat);
        }

        public override double Hatekonysag()
        {
            return (MaxToltotomeg * maxFordulat) / 15400.0;
        }

        public double VizFelhasznalas(MosogepProgram mosogepProgram, double tomeg)
        {
            if (tomeg > MaxToltotomeg) throw new NagyMaximalisToltotomegException();
            double returnValue = 0.0;
            switch (mosogepProgram)
            {
                case MosogepProgram.GYAPJU:
                    returnValue = tomeg / 2;
                    break;
                case MosogepProgram.ECO:
                    returnValue = tomeg / 3;
                    break;
                case MosogepProgram.EXTRA:
                    returnValue = tomeg / 1.5;
                    break;
                case MosogepProgram.CENTRIFUGA:
                    returnValue = 0;
                    break;
                default:
                    break;
            }
            return Math.Round(returnValue, 1);
        }

        public override string ToString()
        {
            return base.ToString() + $" maxTöltőTömeg: {MaxToltotomeg}, maxFordulat: {MaxFordulat}";
        }
    }
}
