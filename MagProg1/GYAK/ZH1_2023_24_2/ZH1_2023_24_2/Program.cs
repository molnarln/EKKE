using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH1_2023_24_2
{
    internal class Program
    {
        static string[] csokoladekSzine = new string[] { "ét", "tej", "fehér" };
        static int SulyCsokoladekSzine = 10;
        static int ArCsokoladekSzine = 150;

        static string[] csokoladeMogyoroDio = new string[] { "mogyorós", "diós" };
        static int SulycsokoladeMogyoroDio = 20;
        static int ArcsokoladeMogyoroDio = 200;

        static string[] csokoladekEgyeb = new string[] { "szilvás", "pisztáciás", "nugátos", "ananászos" };
        static int SulycsokoladekEgyeb = 30;
        static int ArcsokoladekEgyeb = 300;

        static int kapacitas = 120;

        static void Main(string[] args)
        {
            string valasztas;
            int osszeg = 0;
            int osszSuly = 0;

            do
            {
                Console.Write("Adja meg a következő csokoládét: ");
                valasztas = Console.ReadLine().Trim().ToLower();

                if (!csokoladekSzine.Contains(valasztas) && !csokoladeMogyoroDio.Contains(valasztas) && !csokoladekEgyeb.Contains(valasztas))
                {
                    continue;
                }

                for (int i = 0; i < csokoladekSzine.Length; i++)
                {
                    if (csokoladekSzine[i] == valasztas)
                    {
                        osszSuly += SulyCsokoladekSzine;
                        osszeg += ArCsokoladekSzine;
                    }

                }

                for (int i = 0; i < csokoladeMogyoroDio.Length; i++)
                {
                    if (csokoladeMogyoroDio[i] == valasztas)
                    {
                        osszSuly += SulycsokoladeMogyoroDio;
                        osszeg += ArcsokoladeMogyoroDio;
                    }

                }

                for (int i = 0; i < csokoladekEgyeb.Length; i++)
                {
                    if (csokoladekEgyeb[i] == valasztas)
                    {
                        osszSuly += SulycsokoladekEgyeb;
                        osszeg += ArcsokoladekEgyeb;
                    }

                }


            } while (valasztas != "végeztem");

            int dobozokSzama = (int)Math.Ceiling(osszSuly / 120d);
            int vegOsszeg = osszeg + dobozokSzama * 100;

            Console.WriteLine("Dobozok száma: {0}, végösszeg: {1}", dobozokSzama, vegOsszeg);

            Console.ReadLine();

        }
    }
}
