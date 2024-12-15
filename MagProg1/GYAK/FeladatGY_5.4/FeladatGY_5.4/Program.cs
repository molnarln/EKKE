using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeladatGY_5._4
{
    internal class Program
    {
        static int[] szamok = new int[5];
        static void Main(string[] args)
        {
            int megadottszamok = 0;
            int helytelenMegadas = 0;
            while (megadottszamok < 5)
            {
                bool helyesSzamotAdottMeg = true;
                Console.WriteLine("Adja meg a következő számot: ");
                int kovetkezoSzam = int.Parse(Console.ReadLine());

                for (int i = 0; i < szamok.Length; i++)
                {
                    if (kovetkezoSzam == szamok[i])
                    {
                        Console.WriteLine("Ezt a számot már korábban megadta!");
                        helyesSzamotAdottMeg = false;
                    }
                }
                if (kovetkezoSzam < 10 || kovetkezoSzam > 100)
                {
                    Console.WriteLine("Csak 10 és 100 közötti számokat adhat meg!");
                    helyesSzamotAdottMeg = false;
                }
                else if (kovetkezoSzam % 2 != 0)
                {
                    Console.WriteLine("Csak páros számokat adhat meg!");
                    helyesSzamotAdottMeg = false;
                }
                if (!helyesSzamotAdottMeg)
                {
                    helytelenMegadas++;
                    if (helytelenMegadas == 10)
                    {
                        Console.WriteLine("Biztonsagi okokból letiltva!");
                        Console.ReadLine();
                        return;
                    }
                    continue;
                }
                helytelenMegadas = 0;
                szamok[megadottszamok] = kovetkezoSzam;
                megadottszamok++;
            }
            
            Console.Write("A következő számokat adta meg: ");
            for (int i = 0; i < szamok.Length; i++)
            {
                Console.Write(szamok[i] + " ");
            }

            Console.ReadLine();
        }
    }
}
