using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JAV_2022_23_I_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int versenyzokSzama;
            do
            {
                Console.WriteLine("Adja meg a versenyző számát!");

            } while (!int.TryParse(Console.ReadLine(), out versenyzokSzama) || versenyzokSzama < 15 || versenyzokSzama > 100);

            int[] halak = new int[versenyzokSzama];

            Random rnd = new Random();

            int osszTomeg = 0;
            for (int i = 0; i < halak.Length; i++)
            {
                int nextRandom = rnd.Next(1500, 25001);
                halak[i] = nextRandom;
                osszTomeg += nextRandom;
            }

            Console.WriteLine("A halak átlagos tömege: {0:0.##} gramm", (double)osszTomeg / versenyzokSzama);

            int legnagyobbHal = int.MinValue;
            int versenyzoIndex = 0;
            int nyolckilonalKisebbHalakOssztomege = 0;
            for (int i = 0; i < halak.Length; i++)
            {
                if (halak[i] > legnagyobbHal)
                {
                    legnagyobbHal = halak[i];
                    versenyzoIndex = i;

                }
                if (halak[i] < 8000)
                {
                    nyolckilonalKisebbHalakOssztomege += halak[i];
                }
            }

            Console.WriteLine("A legnagyobb hal tömege {0:0.##} kg, versenyző: {1}", AtvaltasKgba(legnagyobbHal), versenyzoIndex + 1);

            Console.WriteLine("Az elérhető bevétel: {0:N0}Ft, {1:0.00}kg hal eladásából", AtvaltasKgba(nyolckilonalKisebbHalakOssztomege) * 2350, AtvaltasKgba(nyolckilonalKisebbHalakOssztomege));


            Console.ReadLine();
        }


        static double AtvaltasKgba(int inputGrammban)
        {
            return inputGrammban / 1000.0;
        }
    }
}
