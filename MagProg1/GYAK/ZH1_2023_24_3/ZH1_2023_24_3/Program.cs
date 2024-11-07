using System;
using System.Text;

namespace ZH1_2023_24_3
{
    internal class Program
    {
        static int TermekSzamaPerEmelet = 12;

        static void Main(string[] args)
        {
            int emeletekSzama;
            int letszam = 0;

            Console.Write("Adja meg az épület emeleteinek számát: ");

            if (!int.TryParse(Console.ReadLine(), out emeletekSzama) || emeletekSzama < 10 || emeletekSzama > 25)
            {
                Console.WriteLine("Az emeletek száma 10 és 25 közé kell essen!");
            }

            int[] letSzamok = new int[emeletekSzama * TermekSzamaPerEmelet];

            Random rnd = new Random();

            for (int i = 0; i < letSzamok.Length; i++)
            {
                letSzamok[i] = rnd.Next(15, 41);
                letszam += letSzamok[i];
            }

            int osszFerohely = emeletekSzama * TermekSzamaPerEmelet * 40;
            double kihasznaltsag = (double)letszam / osszFerohely;

            Console.WriteLine("A termek kihasználtsága {0:0.00}%", kihasznaltsag * 100);
            bool vanMinimalisKihasznaltsaguTerem = false;
            for (int i = 0; i < letSzamok.Length; i++)
            {
                if (letSzamok[i] == 15)
                {
                    vanMinimalisKihasznaltsaguTerem = true;
                    break;
                }
            }

            Console.WriteLine("{0} minimális kihasználtsággal működő terem.", vanMinimalisKihasznaltsaguTerem ? "Van" : "Nincs");

            for (int i = 0; i < emeletekSzama; i++)
            {
                int legMagasabbKihasznlatsag = int.MinValue;
                int legAlacsonyabbKihasznaltsag = int.MaxValue;
                int osszKihasznaltsagEmeleti = 0;
                for (int j = 0; j < TermekSzamaPerEmelet; j++)
                {
                    if (letSzamok[i * TermekSzamaPerEmelet + j] > legMagasabbKihasznlatsag)
                    {
                        legMagasabbKihasznlatsag = letSzamok[i * TermekSzamaPerEmelet + j];
                    }
                    if (letSzamok[i * TermekSzamaPerEmelet + j] < legAlacsonyabbKihasznaltsag)
                    {
                        legAlacsonyabbKihasznaltsag = letSzamok[i * TermekSzamaPerEmelet + j];
                    }
                    osszKihasznaltsagEmeleti += letSzamok[i * TermekSzamaPerEmelet + j];
                }

                Console.WriteLine("A legmagasabb és legalacsonyabb kihasználtság különbsége az {0}. emelet esetén: {1}", i, legMagasabbKihasznlatsag - legAlacsonyabbKihasznaltsag);

                if (osszKihasznaltsagEmeleti == 12 * 40)
                {
                    Console.WriteLine("A {0}. emelet maximális kihasználtságú.", i);
                }
            }

            Console.ReadLine();
        }
    }
}
