using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Minta_ZH1
{
    internal class Gepkocsi
    {

        private string rendszam;
        public string Rendszam
        {
            get { return rendszam; }
            private set
            {

                if (String.IsNullOrWhiteSpace(value)) throw new Exception("Érték nem lehet null vagy whitespce!");
                if (value.Length != 7) throw new Exception("Hossz nem megfelelő");
                rendszam = value;
            }
        }

        private bool evjaratMegadva = false;
        private int evjarat;
        public int Evjarat
        {
            get { return evjarat; }
            private set
            {
                if (value < 1950 || value > DateTime.Now.Year) throw new Exception("Nem megfelelő évjárat!");
                if (evjaratMegadva) throw new Exception("Évjárat csak egyszer adható meg!");
                evjarat = value;
                evjaratMegadva = true;
            }
        }

        private bool eredetiArMegadva = false;
        private int eredetiAr;

        public int GetEredetiAr()
        {
            return eredetiAr;
        }
        private void SetEredetiAr(int eredetiAr)
        {
            if (eredetiArMegadva) throw new Exception("Eredeti ár már meg van adva!");
            this.eredetiAr = eredetiAr;
        }

        public Allapot Allapot { get; set; }

        public int Kor
        {
            get
            {
                return DateTime.Now.Year - this.evjarat;
            }
        }

        private int extraAr;

        public virtual int ExtraAr
        {
            get { return Convert.ToInt32(Kor <= 2 ? eredetiAr * 0.02 : 0); }
        }

        public Gepkocsi(string rendszam, int evjarat, int eredetiAr, Allapot allapot)
        {
            this.rendszam = rendszam;
            this.evjarat = evjarat;
            this.eredetiAr = eredetiAr;
            this.Allapot = allapot;
        }

        public Gepkocsi(string rendszam, int evjarat, int eredetiAr) : this(rendszam, evjarat, eredetiAr, Allapot.Megkimelt)
        {

        }

        public virtual int VetelAr()
        {
            double amortizacio;
            switch (this.Allapot)
            {
                case Allapot.Ujszeru: amortizacio = 0.09;
                    break;
                case Allapot.Megkimelt:
                    amortizacio = 0.1;
                    break;
                case Allapot.Serult:
                    amortizacio = 0.11;
                    break;
                case Allapot.Hibas:
                    amortizacio = 0.12;
                    break;
                default:
                    amortizacio = 0;
                    break;
            }

            return Convert.ToInt32(this.GetEredetiAr() * Math.Pow(amortizacio, this.Kor) + this.ExtraAr);
        }
        public override string ToString()
        {
            return $"Rendszam: {this.Rendszam}, évjárat: {this.Evjarat},  eredeti ár: {this.GetEredetiAr()}, állapot: {this.Allapot}, kor: {this.Kor}, extra ár: {this.ExtraAr}, vételÁr:{this.VetelAr()}";
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (!(obj is Gepkocsi)) return false;
            Gepkocsi masik = obj as Gepkocsi;
            return this.Rendszam == masik.Rendszam;    
        }
    }
}
