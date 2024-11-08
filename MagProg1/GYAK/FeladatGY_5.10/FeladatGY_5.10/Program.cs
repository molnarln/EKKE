using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FeladatGY_5._10
{
    internal class Program
    {
        static double[] vizallasok = new double[366];

        static void Main(string[] args)
        {
            Random rnd = new Random();

            for (int i = 0; i < vizallasok.Length; i++)
            {
                vizallasok[i] = rnd.Next(20, 700) / 100.0;
            }
            int year = DateTime.Now.Year;
            int elteltNapok = 0;
            int veszelyhelyzetiHonapokSzama = 0;
            for (int honap = 0; honap < 12; honap++)
            {
                double haviOsszeg = 0.0;
                double haviMin = double.MaxValue;
                double haviMax = double.MinValue;

                Console.WriteLine("Napi vizallasok {0}. hónapban: ", honap + 1);

                bool veszelyhelyzet = false;
                for (int nap = 0; nap < DateTime.DaysInMonth(year, honap + 1); nap++)
                {
                    haviOsszeg += vizallasok[elteltNapok + nap];
                    Console.WriteLine("Vizallas: {0}", vizallasok[elteltNapok + nap]);
                    if (vizallasok[elteltNapok + nap] < haviMin)
                    {
                        haviMin = vizallasok[elteltNapok + nap];
                    }
                    if (vizallasok[elteltNapok + nap] > haviMax)
                    {
                        haviMax = vizallasok[elteltNapok + nap];
                    }
                    if (vizallasok[elteltNapok + nap] > 4)
                    {
                        veszelyhelyzet = true;
                    }
                }
                elteltNapok += DateTime.DaysInMonth(year, honap + 1);

                Console.WriteLine("Havi atlag: {0:0.00}, havi minimum: {1:0.00}, havi maximum: {2:0.00}, havi ingadozás: {3:0.00}", haviOsszeg / DateTime.DaysInMonth(year, honap + 1), haviMin, haviMax, haviMax - haviMin);

                if (veszelyhelyzet == true)
                {
                    veszelyhelyzetiHonapokSzama++;
                }
                Console.WriteLine("A {0}. hónapban {1} volt veszélyhelyzet.", honap + 1, veszelyhelyzet ? "" : "nem");

            }
            if (veszelyhelyzetiHonapokSzama == 12)
            {
                Console.WriteLine("Az adott év katasztrofális.");
            }

            Console.ReadLine();
        }
    }
}
