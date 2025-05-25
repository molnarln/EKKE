using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH2_Minta_Szenzorok
{
    public class Homero : Szenzor, IHomero
    {
        private static Random rnd = new Random();
        private bool aktiv;
        public override bool Aktiv
        {
            get { return this.aktiv; }
        }

        public void SetAktiv(bool aktiv)
        {
            this.aktiv = aktiv;
        }

        private int alsoHatar;

        public int AlsoHatar
        {
            get { return alsoHatar; }
            private set
            {
                if (value < -60)
                {
                    throw new AlacsonyAlsoHatarException();
                }
            }
        }

        public int FelsoHatar { get; private set; }

        public Homero(int pozicioX, int pozicioY, int alsoHatar, int felsoHatar) : base(new Pozicio(pozicioX, pozicioY))
        {
            HatarokatBeallit(alsoHatar, felsoHatar);
            SetAktiv(true);
        }

        public override void Adatkuldes()
        {
            double meres = HomersekletetMer();
            Console.WriteLine($"Hőmérséklet a(z) ({Pozicio.x} ;{Pozicio.y}) pozíción {DateTime.Now} időpontban : {meres}°C");
        }

        public override object Clone()
        {
            return this.MemberwiseClone(); //megoldani a Pozicio-t memberwise helyett
        }

        public void HatarokatBeallit(int alsoHatar, int felsoHatar)
        {
            AlsoHatar = alsoHatar;
            FelsoHatar = felsoHatar;
        }

        public double HomersekletetMer()
        {
            if (!Aktiv)
            {
                throw new SzenzorInaktivException();
            }

            return rnd.Next(AlsoHatar * 100, FelsoHatar * 100) / 100.0;
        }

        public override string ToString()
        {
            return string.Format("Hőmérő: {0}, A:{1} - F{2}",
        base.ToString(), AlsoHatar, FelsoHatar);
        }
    }
}
