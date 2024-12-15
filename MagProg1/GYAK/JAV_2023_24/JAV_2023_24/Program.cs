using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JAV_2023_24
{
    internal class Program
    {
        const int panettoneDarabPerKarton = 20;
        const decimal PanettoneArPerKg = 3599;
        static void Main(string[] args)
        {
            Console.WriteLine("Adja meg, hogy hány kartont készítettek a mai napon!");
            int kartonDarab;
            if (!int.TryParse(Console.ReadLine(), out kartonDarab) || kartonDarab > 45 || kartonDarab < 30)
            {
                Console.WriteLine("Rossz értéket adott meg!");
                Console.ReadLine();
                return;
            }
            int[] panettoneArray = new int[kartonDarab * panettoneDarabPerKarton];
            Random rnd = new Random();
            int panettoneOssztomeg = 0;
            for (int i = 0; i < panettoneArray.Length; i++)
            {
                panettoneArray[i] = rnd.Next(680, 821);
                panettoneOssztomeg += panettoneArray[i];
            }
            double atlagosPanettoneTomeg = (double)panettoneOssztomeg / panettoneArray.Length;
            Console.WriteLine("A panettone-k átlagos tömege: {0:0.00} gramm.", atlagosPanettoneTomeg);
            Console.WriteLine("A panettone-k össztömege kg-ban: {0:0.00} kg.", AtvaltasKgBa(panettoneArray));
            Console.WriteLine("A legyártott panettone-k összértéke {0:n2} Ft", (decimal)Math.Round(AtvaltasKgBa(panettoneArray), 2) * PanettoneArPerKg);

            // A legnehezebb panettone kartonjának megkeresése:
            int legnehezettPanettoneKartonIndex = 0;
            int legnehezebbPanettoneTomeg = 0;

            for (int karton = 0; karton < kartonDarab; karton++)
            {
                for (int panettone = 0; panettone < panettoneDarabPerKarton; panettone++)
                {
                    if (legnehezebbPanettoneTomeg < panettoneArray[karton * panettoneDarabPerKarton + panettone])
                    {
                        legnehezebbPanettoneTomeg = panettoneArray[panettone + karton * panettoneDarabPerKarton];
                        legnehezettPanettoneKartonIndex = karton;
                    }
                }
            }
            Console.WriteLine("A legnehezebb panettne a {0} indexű kartonban van.", legnehezettPanettoneKartonIndex);

            Console.WriteLine("A [700,740] grammos intervallumban lévő panettonek atlagos tomege: {0:0.00} gramm, míg a [690,750] grammos intervallumban {1:0.00} gramm", AtlagosTomegIntervallumban(panettoneArray, 700, 740), AtlagosTomegIntervallumban(panettoneArray, 690, 750));

            for (int karton = 0; karton < kartonDarab; karton++)
            {
                bool vanNagyobbMint800 = false;
                for (int panettone = 0; panettone < panettoneDarabPerKarton; panettone++)
                {
                    if (800 < panettoneArray[karton * panettoneDarabPerKarton + panettone])
                    {
                        vanNagyobbMint800 = true;
                    }
                }
                Console.WriteLine("A {0}. indexű kartonban {1} 800gnál nagyobb tömegű pannetone", karton, vanNagyobbMint800 ? "van" : "nincs");
            }
            bool van780gnalKisebbKarton = false;
            for (int karton = 0; karton < kartonDarab; karton++)
            {
                int kartonOssztomeg = 0;
                for (int panettone = 0; panettone < panettoneDarabPerKarton; panettone++)
                {
                    kartonOssztomeg += panettoneArray[karton * panettoneDarabPerKarton + panettone];
                }
                double kartonAtlagTomeg = (double)kartonOssztomeg / panettoneDarabPerKarton;
                if (kartonAtlagTomeg < 780)
                {
                    van780gnalKisebbKarton = true;
                    break;
                }
            }
            Console.WriteLine("{0} 780 grammnál kisebb átlagos tömegű karton", van780gnalKisebbKarton ? "Van" : "Nincs");

            Console.ReadLine();
        }

        public static double AtvaltasKgBa(int[] input)
        {
            int osszegGramm = 0;
            for (int i = 0; i < input.Length; i++)
            {
                osszegGramm += input[i];
            }
            return osszegGramm / 1000.0;
        }

        public static double AtlagosTomegIntervallumban(int[] inputTomb, int alsoHatar, int felsoHatar)
        {
            int osszTomegIntervallumKozott = 0;
            int darabszamIntervallumKözött = 0;
            for (int i = 0; i < inputTomb.Length; i++)
            {
                if (inputTomb[i] >= alsoHatar && inputTomb[i] <= felsoHatar)
                {
                    osszTomegIntervallumKozott += inputTomb[i];
                    darabszamIntervallumKözött++;
                }
            }
            if (darabszamIntervallumKözött != 0)
            {
                return (double)osszTomegIntervallumKozott / darabszamIntervallumKözött;
            }
            return 0d;
        }
    }
}
