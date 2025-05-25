using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minta_ZH1
{
    internal class Szemelygepkocsi : Gepkocsi
    {
        private int szallithatoSzemelyekSzama;

        public int SzallithatoSzemelyekSzama
        {
            get { return szallithatoSzemelyekSzama; }
            private set
            {
                if (value != 2 && value != 4 && value != 5 && value != 7) throw new Exception("Nem megfelelő érték!");
                szallithatoSzemelyekSzama = value;
            }
        }
        public bool VanVonohorog { get; set; }

        public Klima Klima { get; set; }

        public override int ExtraAr
        {
            get
            {
                int ar = base.ExtraAr;
                if (VanVonohorog)
                {
                    ar += 60000;
                }
                if (szallithatoSzemelyekSzama == 7)
                {
                    ar += 100000;
                }

                switch (Klima)
                {
                    case Klima.Nincs:
                        break;
                    case Klima.Manualis:
                        ar += 40000;
                        break;
                    case Klima.Digitalis:
                        ar += 150000;
                        break;
                    case Klima.DigitalisTobbzonas:
                        ar += 350000;
                        break;
                    default:
                        break;
                }
                return ar;
            }
        }
        public Szemelygepkocsi(string rendszam, int evjarat, int eredetiAr, Allapot allapot, Klima klima, bool vanVonohorog):base(rendszam, evjarat, eredetiAr, allapot)
        {
            this.Klima = klima;
            this.VanVonohorog = vanVonohorog;
        }

        public Szemelygepkocsi(string rendszam, int evjarat, int eredetiAr, bool vanVonohorog):this(rendszam, evjarat, eredetiAr, Allapot.Megkimelt, Klima.Digitalis, vanVonohorog)
        {
            
        }
        public override int VetelAr()
        {
            double amortizacio;
            switch (this.Allapot)
            {
                case Allapot.Ujszeru:
                    amortizacio = 0.08;
                    break;
                case Allapot.Megkimelt:
                    amortizacio = 0.09;
                    break;
                case Allapot.Serult:
                    amortizacio = 0.12;
                    break;
                case Allapot.Hibas:
                    amortizacio = 0.13;
                    break;
                default:
                    amortizacio = 0;
                    break;
            }
            if (SzallithatoSzemelyekSzama == 7)
            {
                amortizacio *= 1.2;
            }

            return Convert.ToInt32(this.GetEredetiAr() * Math.Pow(amortizacio, this.Kor) + this.ExtraAr);
        }
        public override string ToString()
        {
            return base.ToString() + $" van vonóhorog: {(this.VanVonohorog?"igen":"nem")} klima: {this.Klima}";
        }
    }
}