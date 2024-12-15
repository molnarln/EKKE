using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _01_2022_23
{
    internal class Program
    {
        const int ar95magan = 450;
        const int ar95ceges = 800;
        const int pont95 = 1;

        const int ar100magan = 830;
        const int ar100ceges = 830;
        const int pont100 = 5;


        static void Main(string[] args)
        {
            Console.WriteLine("Adja meg, hogy milyen típusú gépjárműbe tankol:");
            string tipus = Console.ReadLine();

            int uzemanyagTipus;
            double tankoltMennyiseg;
            do
            {
                Console.WriteLine("Adja meg, hogy milyen típusú benzint tankol!");

            } while (!int.TryParse(Console.ReadLine(), out uzemanyagTipus) || (uzemanyagTipus != 95 && uzemanyagTipus != 100));

            do
            {
                Console.WriteLine("Adja meg, hogy mennyi üzemanyagot tankol!");

            } while (!double.TryParse(Console.ReadLine(), out tankoltMennyiseg) || 0 > tankoltMennyiseg || 50 < tankoltMennyiseg);

            double fizetendo = 0.0;
            int husegpont = 0;
            if (tipus == "magán")
            {
                switch (uzemanyagTipus)
                {
                    case 95:
                        fizetendo = Math.Round(tankoltMennyiseg * ar95magan);
                        husegpont = (int)tankoltMennyiseg * pont95;
                        break;
                    case 100:
                        fizetendo = Math.Round(tankoltMennyiseg * ar100magan);
                        husegpont = (int)tankoltMennyiseg * pont100;
                        break;
                }

            }
            else
            {
                switch (uzemanyagTipus)
                {
                    case 95:
                        fizetendo = Math.Round(tankoltMennyiseg * ar95ceges);
                        husegpont = (int)tankoltMennyiseg * pont95;
                        break;
                    case 100:
                        fizetendo = Math.Round(tankoltMennyiseg * ar100ceges);
                        husegpont = (int)tankoltMennyiseg * pont100;
                        break;
                }
            }
            Console.WriteLine("Fizetendo: {0}", fizetendo);
            Console.WriteLine("Van ajándékkártyája?");
            string vanAjandekkartya = Console.ReadLine();

            if (vanAjandekkartya == "nem")
            {
                Console.WriteLine("Köszönöm a vásárlást!");
            }
            else
                Console.Write("Önnek {0} db hűségpontot írtunk jóvá!", husegpont);

            Console.ReadLine();
        }
    }
}
