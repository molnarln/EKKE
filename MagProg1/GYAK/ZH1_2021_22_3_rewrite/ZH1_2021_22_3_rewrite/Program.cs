using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ZH1_2021_22_3_rewrite
{
    internal class Program
    {
        static int ertekelesekSzama = 5;

        static void Main(string[] args)
        {
            Console.Write("Adja meg a versenyzők számát: ");

            int versenyzokSzama = int.Parse(Console.ReadLine());

            if (versenyzokSzama < 3)
            {
                Console.WriteLine("Túl kevés versenyző indult!");
                return;
            }

            double[] eredmenyek = new double[versenyzokSzama * ertekelesekSzama];
            Random rnd = new Random();

            for (int i = 0; i < eredmenyek.Length; i++)
            {
                eredmenyek[i] = rnd.Next(0, 501) / 100d;
            }

            double maxPontszam = double.MinValue;
            int versenyzoIndex = 0;
            double maxVersenyzoAtlag = double.MinValue;
            int maxVersenyzoAtlagIndexe = 0;
            for (int i = 0; i < versenyzokSzama; i++)
            {
                double versenyzoOsszido = 0;
                bool bena = true;

                for (int j = 0; j < ertekelesekSzama; j++)
                {
                    versenyzoOsszido += eredmenyek[i * 5 + j];
                    if (eredmenyek[i * 5 + j] > maxPontszam)
                    {
                        maxPontszam = eredmenyek[i * 5 + j];
                        versenyzoIndex = i;
                    }
                    if (eredmenyek[i * 5 + j] > 2)
                    {
                        bena = false;
                    }
                }

                double versenyzoatlag = versenyzoOsszido / ertekelesekSzama;
                if (versenyzoatlag > maxVersenyzoAtlag)
                {
                    maxVersenyzoAtlag = versenyzoatlag;
                    maxVersenyzoAtlagIndexe = i;
                }
                Console.WriteLine("A {0}. számú versenyző átlagpontja: {1}", i + 1, versenyzoOsszido / ertekelesekSzama);
                Console.WriteLine("A {0}. számú versenyző {1}", i + 1, bena ? "béna" : "nem béna");
            }
            Console.WriteLine("A legmagasabb pontszáma a {0}. számú versenyzőnek van, mégpedig: {1} pont", versenyzoIndex + 1, maxPontszam);
            Console.WriteLine("A legmagasabb átlagpontja a {0}. versenyzoneőnek van, mégpedig: {1} pont", maxVersenyzoAtlagIndexe + 1, maxVersenyzoAtlag);


            Console.ReadLine();
        }
    }
}
