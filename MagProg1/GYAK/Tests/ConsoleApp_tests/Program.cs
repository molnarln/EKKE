using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_tests
{
    struct Diak
    {
        public string nev;
        public DateTime szulDatum;
        public string varos;
        public double atlag;

        public override string ToString()
        {
            return string.Format("Nev: {0}, szulDatum: {1}, varos: {2}, atlag: {3:0.00}", nev, szulDatum, varos, atlag);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DateTime akt = DateTime.Now;

            Console.WriteLine(akt.ToString("MMMM"));


            //Harom legnagyobb elem egy listában:

            List<int> lista = new List<int>() { 3, 2, 6, 2, 7, 8, 3, 7, 10, 654, 43, 67 };

            lista.Sort();
            lista.Reverse();
            int kiírtElemIndex = 0;
            int aktualisElem = int.MinValue;
            while (kiírtElemIndex < 3)
            {
                if (aktualisElem != lista[kiírtElemIndex])
                {
                    Console.WriteLine(lista[kiírtElemIndex]);
                    aktualisElem = lista[kiírtElemIndex];
                    kiírtElemIndex++;
                }

            }

            Diak ede = new Diak();
            ede.nev = "ede";
            ede.szulDatum = DateTime.Parse("1987.05.04");
            ede.varos = "Eger";
            ede.atlag = 3.0;
            Console.WriteLine("Ede városa: {0}", ede.varos);
            ChangeVaros(ede);
            Console.WriteLine("Ede városa: {0}", ede.varos);
            Console.WriteLine(ede.ToString());
            int testInt = 0;
            int testInt2 = 0;
            testInt2 = ChangeInt(ref testInt);
            Console.WriteLine("testint1: {0}, testint2: {1}", testInt, testInt2);
            int valami = 23;
            CreateInt(out valami);

            Console.WriteLine(valami);

            Console.ReadLine();
        }
        static void ChangeVaros(Diak input)
        {
            //Nem fogja megváltoztatni, mivel Diak egy struct, vagyis value type, egy teljes másolatot kap a fgv.
            input.varos = "Makó";
        }

        static int ChangeInt(ref int input)
        {
            input = 32;
            //Nem fogja megváltoztatni, mivel Diak egy struct, vagyis value type, egy teljes másolatot kap a fgv.
            return 32;
        }

        static bool CreateInt(out int testInt)
        {
            testInt = 234;
            return true;
        }
    }
}
