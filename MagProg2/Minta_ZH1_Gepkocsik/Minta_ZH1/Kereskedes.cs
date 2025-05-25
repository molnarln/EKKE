using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minta_ZH1
{
    internal class Kereskedes
    {
        private List<Gepkocsi> gepkocsik = new List<Gepkocsi>();

        public List<Gepkocsi> GepKocsik
        {
            get { return gepkocsik = new List<Gepkocsi>(); }
        }

        public List<Szemelygepkocsi> Szemelygepkocsik
        {
            get
            {
                List<Szemelygepkocsi> temp = new List<Szemelygepkocsi>();
                foreach (Gepkocsi item in gepkocsik)
                {
                    if (item is Szemelygepkocsi)
                    {
                        temp.Add(item as Szemelygepkocsi);
                    }
                }
                return temp;
            }
        }

        public Szemelygepkocsi LegolcsobbMegkimeltSzemelygepkocsi
        {
            get
            {
                if (!gepkocsik.Any(_ => _ is Szemelygepkocsi))
                {
                    throw new Exception("Nincs egyetlen személygépkocsi sem a listában");
                }
                Szemelygepkocsi temp = null;

                foreach (Szemelygepkocsi item in gepkocsik)
                {
                    if (item is Szemelygepkocsi && item.Allapot == Allapot.Megkimelt)
                    {
                        if (temp == null)
                        {
                            temp = item;
                        }
                        if (temp.VetelAr() > item.VetelAr())
                        {
                            temp = item;
                        }
                    }
                }
                return temp;
            }
        }

        public Gepkocsi this[string rendszam]
        {
            get
            {
                if (!(GepKocsik.Any(_ => _.Rendszam == rendszam)))
                {
                    throw new Exception("Nincs ilyen rendszámú autó");
                }
                return GepKocsik.Where(_ => _.Rendszam == rendszam).First();
            }
        }

        public void AddGepkocsi(Gepkocsi gepkocsi)
        {
            if (!(gepkocsik.Contains(gepkocsi)))
            {
                gepkocsik.Add(gepkocsi);
            }
        }

        public List<Szemelygepkocsi> SzemelygepkocsikAdottArig(Allapot allapot, int maxAr)
        {
            List<Szemelygepkocsi> temp = new List<Szemelygepkocsi>();

            foreach (var item in GepKocsik)
            {
                if (item is Szemelygepkocsi)
                {
                    if (item.Allapot == allapot && item.VetelAr()<=maxAr)
                    {
                        temp.Add(item as Szemelygepkocsi);
                    }
                }
            }
            return temp;
        }
    }
}
