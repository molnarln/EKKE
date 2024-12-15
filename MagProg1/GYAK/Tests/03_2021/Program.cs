using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            int versenyzokSzama;
            Console.Write("Adja meg a versenyzők számát: ");
            if (int.TryParse(Console.ReadLine(), out versenyzokSzama) && versenyzokSzama >= 3)
            {
                double[] ertekelesek = new double[versenyzokSzama * 5];
                Random rnd = new Random();
                for (int i = 0; i < ertekelesek.Length; i++)
                {
                    ertekelesek[i] = rnd.Next(0, 501) / 100.0;
                    Console.WriteLine(ertekelesek[i]);
                }

                Console.WriteLine("A versenyzők átlagos pontszámai: ");

                double maxAtlagErtek = double.MinValue;
                double maxVersenyzoIndex = 0;

                for (int versenyzo = 0; versenyzo < versenyzokSzama; versenyzo++)
                {
                    double versenyzoOsszeredmeny = 0;
                    for (int eredmeny = 0; eredmeny < 5; eredmeny++)
                    {
                        versenyzoOsszeredmeny += ertekelesek[versenyzo * 5 + eredmeny];
                    }
                    double atlag = versenyzoOsszeredmeny / 5;
                    if (atlag > maxAtlagErtek)
                    {
                        maxAtlagErtek = atlag;
                        maxVersenyzoIndex = versenyzo;
                    }

                    Console.WriteLine("Az {0}. versenyző eredményeinek átlaga: {1}", versenyzo + 1, atlag);
                }

                double maxValue = double.MinValue;
                int maxIndex = 0;
                for (int i = 0; i < ertekelesek.Length; i++)
                {
                    if (ertekelesek[i] > maxValue)
                    {
                        maxValue = ertekelesek[i];
                        maxIndex = i;
                    }
                }
                Console.WriteLine("A legmagasabb pontszámmal rendelkező versenyző {0}, a pontszáma: {1}", maxIndex / 5 + 1, maxValue);

                for (int versenyzo = 0; versenyzo < versenyzokSzama; versenyzo++)
                {
                    bool vanKettoFelettiEredmenye = false;
                    for (int eredmeny = 0; eredmeny < 5; eredmeny++)
                    {
                        if (ertekelesek[versenyzo * 5 + eredmeny] > 2.00)
                        {
                            vanKettoFelettiEredmenye = true;
                            break;
                        }
                    }
                    Console.WriteLine("Az {0}. versenyző {1}béna", versenyzo + 1, vanKettoFelettiEredmenye ? "nem " : "");
                }

                Console.WriteLine("A verseny nyertese a {0} számú versenyző, átlaga: {1}", maxVersenyzoIndex + 1, maxAtlagErtek);

                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Sajnos nem jelentkeztek elegen!");
                Console.ReadLine();
            }
        }
    }
}
