using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH1_2022_23_1_rewrite
{
    internal class Program
    {
        static int Ar95Magan = 480;
        static int Ar95Ceges = 800;
        static int Pontok95 = 1;

        static int Ar100Magan = 830;
        static int Ar100Ceges = 830;
        static int Pontok100 = 5;

        static void Main(string[] args)
        {
            Console.WriteLine("Adja meg, hogy milyen típusú gépjárműbe tankol: ");
            string jarmuTipus = Console.ReadLine();

            int benzinTipus;
            do
            {
                Console.WriteLine("Adja meg, hogy milyen típusú benzint tankol (95/100): ");
            } while (!int.TryParse(Console.ReadLine(), out benzinTipus) || !(benzinTipus == 95 || benzinTipus == 100));

            double tankoltMennyiseg;
            do
            {
                Console.WriteLine("Adja meg, hogy mennyit tankol ");
            } while (!double.TryParse(Console.ReadLine(), out tankoltMennyiseg) || tankoltMennyiseg < 1 || tankoltMennyiseg > 50);

            double fizetendo = 0;

            if (jarmuTipus == "magán")
            {
                switch (benzinTipus)
                {
                    case 95:
                        fizetendo = Ar95Magan * tankoltMennyiseg;
                        break;
                    case 100:
                        fizetendo = Ar100Magan * tankoltMennyiseg;
                        break;
                }
            }
            if (jarmuTipus == "cég")
            {
                switch (benzinTipus)
                {
                    case 95:
                        fizetendo = Ar95Ceges * tankoltMennyiseg;
                        break;
                    case 100:
                        fizetendo = Ar100Ceges * tankoltMennyiseg;
                        break;
                }
            }

            Console.WriteLine("A fizetendő összeg: {0}Ft", Math.Round(fizetendo));
            Console.WriteLine("Rendelkezik pontgyűjtő kártyával?");
            
            bool vanPontgyujtoKartya = Console.ReadLine() == "igen" ? true : false;
            int husegPontok = 0;
            
            if (benzinTipus == 95)
            {
                husegPontok = (int)Math.Floor(tankoltMennyiseg) * Pontok95;
            }
            else
            {
                husegPontok = (int)Math.Floor(tankoltMennyiseg) * Pontok100;
            }

            if (!vanPontgyujtoKartya)
            {
                Console.WriteLine("Köszönjük a vásárlást!");
            }
            else
            {
                Console.WriteLine("{0}db hűségpontot írtunk jóvá.", husegPontok);
            }

            Console.ReadLine();
        }
    }
}
