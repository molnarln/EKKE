using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH1_2021_22_1_rewrite
{
    internal class Program
    {
        static int MinimalBer = 2100;


        static void Main(string[] args)
        {
            Console.WriteLine("Adja meg a bruttó keresetét: ");

            int kereset = int.Parse(Console.ReadLine());

            if (kereset < MinimalBer)
            {
                Console.WriteLine("Ön a minimálbérnél alacsonyabb összeget adott meg!");
                return;
            }

            double adokulcs;
            if (kereset < 4200)
            {
                adokulcs = 0.1d;
            }
            else if (kereset < 8000)
            {
                adokulcs = 0.2d;
            }
            else if (kereset < 15000)
            {
                adokulcs = 0.3d;
            }
            else
            {
                adokulcs = 0.4d;
            }

            Console.WriteLine("Adja meg az eltartott gyermekek számát: ");

            int gyermekekSzama = int.Parse(Console.ReadLine());
            if (gyermekekSzama < 0 || gyermekekSzama > 69)
            {
                return;
            }

            if (gyermekekSzama < 2)
            {
                adokulcs *= 0.9;
            }
            else if (gyermekekSzama < 3)
            {
                adokulcs *= 0.8;
            }
            else if (gyermekekSzama < 4)
            {
                adokulcs *= 0.7;
            }
            else
            {
                adokulcs *= 0.6;
            }

            int nettoBer = (int)Math.Round(kereset - (double)adokulcs * kereset);
            int maradek = nettoBer % 10;
            int nettoBer10GubasraKerekitve = (nettoBer / 10) * 10;
     
            if (maradek < 5)
            {
                Console.WriteLine("A nettó keresete: {0}", nettoBer10GubasraKerekitve);

            }
            else
            {
                Console.WriteLine("A nettó keresete: {0}", nettoBer10GubasraKerekitve + 10);
            }

            Console.ReadLine();
        }
    }
}
