using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeladatGY_5._9
{
    internal class Program
    {

        static int[] homersekletAdatok = new int[168];

        static void Main(string[] args)
        {
            Random rnd = new Random();

            for (int i = 0; i < homersekletAdatok.Length; i++)
            {
                homersekletAdatok[i] = rnd.Next(22, 40);
            }
            int hetiMin = int.MaxValue;
            int hetiMax = int.MinValue;
            int hetiHoingas = 0;
            for (int nap = 0; nap < 7; nap++)
            {
                int napiOsszeg = 0;
                int napiMin = int.MaxValue;
                int napiMax = int.MinValue;
                int napiHoingas = 0;
                for (int ora = 0; ora < 24; ora++)
                {
                    napiOsszeg += homersekletAdatok[nap * 24 + ora];
                    if (homersekletAdatok[nap * 24 + ora] < napiMin)
                    {
                        napiMin = homersekletAdatok[nap * 24 + ora];
                    }
                    if (homersekletAdatok[nap * 24 + ora] > napiMax)
                    {
                        napiMax = homersekletAdatok[nap * 24 + ora];
                    }
                }
                napiHoingas = napiMax - napiMin;

                if (napiMin < hetiMin)
                {
                    hetiMin = napiMin;
                }
                if (napiMax > hetiMax)
                {
                    hetiMax = napiMax;
                }
                hetiHoingas = hetiMax - hetiMin;

                Console.WriteLine("{0}. napi átlag: {1:0.00} Celsius fok, napi maximum: {2}, napi minimum: {3}, napi hőingás: {4}", nap + 1, (double)napiOsszeg / 24, napiMax, napiMin, napiHoingas);
            }
            Console.WriteLine("Heti hőingás: {0} Celsius fok", hetiHoingas);

            Console.Write("Adja meg az időintervallum alját: ");
            int also = int.Parse(Console.ReadLine());

            Console.Write("Adja meg az időintervallum tetejét: ");
            int felso = int.Parse(Console.ReadLine());
            int nevezo = felso - also;
            double napiAtlagSzukitettMin = double.MaxValue;
            int napiAtlagSzukitettMinIndex = 0;
            for (int nap = 0; nap < 7; nap++)
            {
                int napiOsszegSzukitett = 0;
                double napiAtlagszukitett = 0;

                for (int ora = 0; ora < 24; ora++)
                {
                    if (ora >= also && ora <= felso)
                    {
                        napiOsszegSzukitett += homersekletAdatok[nap * 24 + ora];
                    }
                }
                napiAtlagszukitett = napiOsszegSzukitett / nevezo;
                
                Console.WriteLine("Atlagok: {0:0.00}", napiAtlagszukitett);
                
                if (napiAtlagszukitett < napiAtlagSzukitettMin)
                {
                    napiAtlagSzukitettMin = napiAtlagszukitett;
                    napiAtlagSzukitettMinIndex = nap;
                }
            }

            Console.WriteLine("Az adott intervallumon a leghidegebb nap: {0}", napiAtlagSzukitettMinIndex + 1);

            Console.ReadLine();
        }
    }
}
