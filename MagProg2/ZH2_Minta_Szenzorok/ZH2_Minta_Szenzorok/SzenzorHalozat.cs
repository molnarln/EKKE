using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH2_Minta_Szenzorok
{

    public class SzenzorHalozat : IEnumerable
    {

        private List<Szenzor> szenzorok;

        public SzenzorHalozat()
        {
            szenzorok = new List<Szenzor>();
        }

        public List<Szenzor> AktivSzenzorok
        {
            get
            {
                return szenzorok.Where(_ => _.Aktiv).OrderBy(_ => _.Pozicio.x).ThenByDescending(_ => _.Pozicio.y).Select(_ => _.Clone()).OfType<Szenzor>().ToList();
            }
        }

        public delegate int HomeroToInt(Homero homero);
        public double AktivAtlag(HomeroToInt homeroToInt)
        {
            int count = 0;
            double sum = 0d;

            foreach (var item in szenzorok)
            {
                if (item.Aktiv)
                {
                    sum += homeroToInt(item as Homero);
                    count++;
                }
            }

            return sum / count;
        }

        public void Telepit(Szenzor szenzor)
        {
            szenzorok.Add(szenzor);
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in szenzorok)
            {
                yield return item.Clone();
            }
        }
    }
}
