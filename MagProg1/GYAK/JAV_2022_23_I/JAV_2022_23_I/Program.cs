using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace JAV_2022_23_I
{
    internal class Program
    {
        static int maxRam = 32;

        static void Main(string[] args)
        {
            // Ha hibás adatbevitel esetén leállítjuk a program végrehajtását:

            //Console.WriteLine("Adja meg, hogy hány RAM slot van az alaplapon!");

            //int slotSzam = int.Parse(Console.ReadLine());

            //if (slotSzam < 2 || slotSzam > 6)
            //{
            //    Console.WriteLine("A slotszám 2 és 6 közé kell essen!");
            //    Console.ReadLine();
            //    return;
            //}
            //int osszRam = 0;
            //int nextRam;
            //int count = 0;
            //while (count < slotSzam && osszRam < maxRam)
            //{
            //    Console.Write("Adja meg a ram méretét! ");
            //    nextRam = int.Parse(Console.ReadLine());
            //    if (nextRam != 2 && nextRam != 4 && nextRam != 6 && nextRam != 8)
            //    {
            //        Console.WriteLine("Csak 2, 4, 6 vagy 8gb-os ram méreteket adhat meg!");
            //        Console.ReadLine();

            //        return;
            //    }
            //    if (osszRam + nextRam > maxRam)
            //    {
            //        Console.WriteLine("Max {0} gb ramot pakolhat a gépbe!", maxRam);
            //        Console.ReadLine();

            //        return;
            //    }
            //    osszRam += nextRam;

            //    count++;
            //}
            //Console.WriteLine("A gépbe {0}GB ram került {1} slotba.", osszRam, slotSzam);
            //Console.ReadLine();

            //Ha minden adatbekérés addig történik, amíg helyes adatot nem ad meg:
            //int slotSzam;
            //do
            //{
            //    Console.WriteLine("Adja meg, hogy hány RAM slot van az alaplapon!");

            //} while (!int.TryParse(Console.ReadLine(), out slotSzam) || slotSzam < 2 || slotSzam > 6);
            //int osszRam = 0;
            //int nextRam;
            //int count = 0;
            //while (count < slotSzam && osszRam < maxRam)
            //{

            //    do
            //    {
            //    Console.Write("Adja meg a ram méretét! ");

            //    } while (!int.TryParse(Console.ReadLine(), out nextRam) || (nextRam != 2 && nextRam != 4 && nextRam != 6 && nextRam != 8) || (osszRam + nextRam > maxRam));

            //    osszRam += nextRam;

            //    count++;
            //}
            //Console.WriteLine("A gépbe {0}GB ram került {1} slotba.", osszRam, slotSzam);
            //Console.ReadLine();


            //Ha folyamatosan kérjük be az adatokat, és ki is írjuk, va valami hibás:

            int slotSzam = 0;

            while (slotSzam < 2 || slotSzam > 6)
            {
                Console.WriteLine("Adja meg, hogy hány RAM slot van az alaplapon!");
                slotSzam = int.Parse(Console.ReadLine());
                if (slotSzam < 2 || slotSzam > 6)
                {
                    Console.WriteLine("A slotszám 2 és 6 közé kell essen!");
                    continue;
                }
            }

            if (slotSzam < 2 || slotSzam > 6)
            {
                Console.WriteLine("A slotszám 2 és 6 közé kell essen!");
                Console.ReadLine();
                return;
            }
            int osszRam = 0;
            int nextRam = 0;
            int count = 0;
            while (count < slotSzam && osszRam < maxRam)
            {
                while (nextRam != 2 && nextRam != 4 && nextRam != 6 && nextRam != 8)
                {
                    Console.Write("Adja meg a ram méretét! ");
                    nextRam = int.Parse(Console.ReadLine());

                    if (nextRam != 2 && nextRam != 4 && nextRam != 6 && nextRam != 8)
                    {
                        Console.WriteLine("Csak 2, 4, 6 vagy 8gb-os ram méreteket adhat meg!");
                        nextRam = 0;
                        continue;
                    }
                    if (osszRam + nextRam > maxRam)
                    {
                        Console.WriteLine("Max {0} gb ramot pakolhat a gépbe!", maxRam);
                        nextRam = 0;
                        continue;
                    }
                }

                osszRam += nextRam;
                nextRam = 0;

                count++;
            }
            Console.WriteLine("A gépbe {0}GB ram került {1} slotba.", osszRam, slotSzam);
            Console.ReadLine();
        }
    }
}
