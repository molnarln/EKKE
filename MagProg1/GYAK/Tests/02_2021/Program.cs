using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ervenyesValutak = new int[] { 10, 20, 50, 100, 200 };
            int kifizetendo;
            int megadottValuta;
            do
            {
                Console.Write("Adja meg a kifizetendő összeget: ");

            } while (!int.TryParse(Console.ReadLine(), out kifizetendo) || 0 > kifizetendo || kifizetendo > 2000 || kifizetendo % 10 != 0);

            while (kifizetendo > 0)
            {
                do
                {
                    Console.Write("Adjon egy érvényes valutát: ", kifizetendo);
                } while (!EllenorzottValutacheck(ervenyesValutak, out megadottValuta));

                if (kifizetendo < megadottValuta)
                {
                    Console.WriteLine("Túl nagy összeget adott meg!");
                }
                else
                {
                    kifizetendo -= megadottValuta;
                    if (kifizetendo != 0)
                        Console.WriteLine("A fennmaradó tartozás: {0}", kifizetendo);

                }

            }
            Console.WriteLine("Nincs több tartozása");
            Console.ReadLine();
        }

        static bool ValutaErvenyes(int[] valutak, int megadottValuta)
        {
            for (int i = 0; i < valutak.Length; i++)
            {
                if (valutak[i] == megadottValuta) return true;
            }
            return false;
        }

        static bool EllenorzottValutacheck(int[] ervenyesValutak, out int megadottValuta)
        {
            bool parseSikeres = int.TryParse(Console.ReadLine(), out megadottValuta);
            bool valutaErvenyes = ValutaErvenyes(ervenyesValutak, megadottValuta);

            return parseSikeres && valutaErvenyes;
        }
    }
}
