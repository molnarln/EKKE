using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH1_2022_23_3
{
    internal class Program
    {
        static int NapokSzama = 14;
        static int ArPerTizCenti = 500;

        static void Main(string[] args)
        {
            int napiKitermeltMennyiseg;

            do
            {
                Console.WriteLine("Adja meg, hogy mennyi fát tudnak kitermelni egy nap alatt: ");
            } while (!int.TryParse(Console.ReadLine(), out napiKitermeltMennyiseg) || napiKitermeltMennyiseg < 35 || napiKitermeltMennyiseg > 55);

            int[] fak = new int[NapokSzama * napiKitermeltMennyiseg];

            Random rnd = new Random();

            for (int i = 0; i < fak.Length; i++)
            {
                fak[i] = rnd.Next(150, 301);
            }

            int legkisebbFaMagassag = int.MaxValue;
            int legkisebbFaNapIndex = 0;

            int maxKitermeles = int.MinValue;
            int maxKitermelesNapIndex = 0;

            for (int i = 0; i < NapokSzama; i++)
            {
                int napiBevetel = 0;
                int osszMagassag = 0;
                for (int j = 0; j < napiKitermeltMennyiseg; j++)
                {
                    osszMagassag += fak[i * napiKitermeltMennyiseg + j];
                    if (fak[i * napiKitermeltMennyiseg + j] < legkisebbFaMagassag)
                    {
                        legkisebbFaMagassag = fak[i * napiKitermeltMennyiseg + j];
                        legkisebbFaNapIndex = i;
                    }
                    int megkezdett10Centik = fak[i * napiKitermeltMennyiseg + j] / 10;
                    napiBevetel += megkezdett10Centik * ArPerTizCenti;
                }

                double napiAtlag = (double)osszMagassag / napiKitermeltMennyiseg;
                if (napiBevetel > maxKitermeles)
                {
                    maxKitermeles = napiBevetel;
                    maxKitermelesNapIndex = i;
                }


                Console.WriteLine("A {0}. napi átlagmagasság {1:0.00}m", i + 1, napiAtlag / 100);
                Console.WriteLine("Napi maximális bevétel {0}", napiBevetel);
            }
            Console.WriteLine("A legkisebb fát a {0}. napon termelték ki, magassága {1}cm", legkisebbFaNapIndex + 1, legkisebbFaMagassag);
            Console.WriteLine("A legnagyobb értékű kitermelés a {0}. napon volt.", maxKitermelesNapIndex + 1);


            Console.ReadLine();
        }
    }
}
