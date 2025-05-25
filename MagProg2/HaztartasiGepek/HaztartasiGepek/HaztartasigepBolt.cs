using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaztartasiGepek
{
    public class HaztartasigepBolt : IEnumerable
    {
        public HaztartasigepBolt()
        {
            gepek = new List<Nagygep>();
        }
        private List<Nagygep> gepek;

        public void Elment(Nagygep nagygep)
        {
            if (gepek.Contains(nagygep)) throw new Exception("A gép már létezik!");
            gepek.Add(nagygep);
            gepek.Sort();
            gepek.Reverse();
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in gepek)
            {
                yield return item.Clone();
            }
        }

        public List<Nagygep> NepszeruNagyGepek
        {
            get
            {
                return gepek.Where(_ => _.Gyarto.Nepszeru).Select(_ => _.Clone()).OfType<Nagygep>().ToList();
            }
        }

        public List<Mosogep> HaromLegrelevansabbPhilipsMosogepLegalabb1100AsFordulattal
        {
            get
            {
                return gepek
                    .Where(_ => _.Gyarto.Nev == "Philips")
                    .OrderByDescending(_ => _.Relevancia)
                    .ThenByDescending(_=>_.Hatekonysag())
                    .ThenBy(_=>_.Tipus).Take(3)
                    .OfType<Mosogep>()
                    .ToList();
            }
        }
        public Mosogep this[int index]
        {
            get
            {
                return gepek[index] as Mosogep;
            }
        }
        public bool VanOlyanAmi(Predicate<Mosogep> predicate)
        {
            foreach (var item in gepek)
            {
                if (predicate(item as Mosogep)) return true;
            }
            return false;
        }
    }
}
