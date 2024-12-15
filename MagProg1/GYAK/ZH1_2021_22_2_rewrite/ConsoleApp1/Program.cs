using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static int[] ervenyesValutak = new int[] { 10, 20, 50, 100, 200 };
        static void Main(string[] args)
        {
            int kifizetendoOsszeg = -1;

            //Ha a hibás adatbevitelek okát nem írjuk ki a console-ra
            //do
            //{
            //    Console.Write("Adja meg a kifizetendő összeget: ");

            //} while (!int.TryParse(Console.ReadLine(), out kifizetendoOsszeg) || kifizetendoOsszeg < 0 || kifizetendoOsszeg > 2000 || !(kifizetendoOsszeg % 10 == 0));

            //Ha minden hibás adatbevitel okát is szeretnénk közölni:
            while (kifizetendoOsszeg < 0 || kifizetendoOsszeg > 2000 || !(kifizetendoOsszeg % 10 == 0))
            {
                Console.Write("Adja meg a kifizetendő összeget: ");

                int.TryParse(Console.ReadLine(), out kifizetendoOsszeg);

                if (kifizetendoOsszeg < 0)
                {
                    Console.WriteLine("A kifizetendő összeg nem lehet negatív!");
                    continue;
                }
                if (kifizetendoOsszeg > 2000)
                {

                    Console.WriteLine("A kifizetendő összeg nem lehet nagyobb, mint 2000!");
                    continue;
                }
                if ((kifizetendoOsszeg % 10) != 0)
                {

                    Console.WriteLine("A kifizetendő összeg 10-el osztható kell, hogy legyen!");
                    continue;
                }
            }

            while (kifizetendoOsszeg > 0)
            {
                int megadottValuta;
                Console.Write("Adja meg a valutát: ");
                int.TryParse(Console.ReadLine(), out megadottValuta);
                if (megadottValuta > kifizetendoOsszeg)
                {
                    Console.WriteLine("Túl nagy összeget adott meg!");
                    continue;
                }
                bool megadottValutaErvenyes = false;

                for (int i = 0; i < ervenyesValutak.Length; i++)
                {
                    if (ervenyesValutak[i] == megadottValuta)
                    {
                        megadottValutaErvenyes = true;
                        break;
                    }

                }
                if (!megadottValutaErvenyes)
                {
                    Console.WriteLine("A megadott valuta érvénytelen!");
                    continue;
                }
                kifizetendoOsszeg -= megadottValuta;
                if (kifizetendoOsszeg > 0)
                {
                    Console.WriteLine("Fennmaradt tartozás: {0}", kifizetendoOsszeg);
                }
                else
                {
                    Console.WriteLine("Önnek nincs további tartozása!");
                }
            }

            Console.ReadLine();
        }
    }
}
