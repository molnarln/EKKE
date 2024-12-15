using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH1_2022_23_2
{
    internal class Program
    {
        static int alapAr = 1350;

        static string[] feltetKategoria1 = new string[] { "sonka", "kukorica", "gomba" };
        static int feltetKategoria1Ar = 200;

        static string[] feltetKategoria2 = new string[] { "kolbász", "ananász", "jalapenho" };
        static int feltetKategoria2Ar = 250;

        static string[] feltetKategoria3 = new string[] { "kagyló", "articsóka", "oliv" };
        static int feltetKategoria3Ar = 300;

        static void Main(string[] args)
        {
            Console.WriteLine("Üdvözli Önt a MixAPizza pizzéria!");

            int feltetekDarab = 0;
            int teljesAr = alapAr;

            string valasztottFeltet;
            
            //Hátultesztelő verzió:

            //do
            //{
            //    Console.Write("Adja meg a következő választott feltétet: ");
            //    valasztottFeltet = Console.ReadLine();
            //    if (valasztottFeltet == "-")
            //    {
            //        break;
            //    }

            //    for (int i = 0; i < feltetKategoria1.Length; i++)
            //    {
            //        if (valasztottFeltet == feltetKategoria1[i])
            //        {
            //            teljesAr += feltetKategoria1Ar;
            //            feltetekDarab++;
            //        }
            //    }
            //    for (int i = 0; i < feltetKategoria2.Length; i++)
            //    {
            //        if (valasztottFeltet == feltetKategoria2[i])
            //        {
            //            teljesAr += feltetKategoria2Ar;
            //            feltetekDarab++;
            //        }
            //    }
            //    for (int i = 0; i < feltetKategoria3.Length; i++)
            //    {
            //        if (valasztottFeltet == feltetKategoria3[i])
            //        {
            //            teljesAr += feltetKategoria3Ar;
            //            feltetekDarab++;
            //        }
            //    }

            //} while (feltetekDarab <= 5);

            // Elöltesztelő verzió:

            while (feltetekDarab <= 5)
            {
                Console.Write("Adja meg a következő választott feltétet: ");
                
                valasztottFeltet = Console.ReadLine();
                
                if (valasztottFeltet == "-")
                {
                    break;
                }

                for (int i = 0; i < feltetKategoria1.Length; i++)
                {
                    if (valasztottFeltet == feltetKategoria1[i])
                    {
                        teljesAr += feltetKategoria1Ar;
                        feltetekDarab++;
                    }
                }
                for (int i = 0; i < feltetKategoria2.Length; i++)
                {
                    if (valasztottFeltet == feltetKategoria2[i])
                    {
                        teljesAr += feltetKategoria2Ar;
                        feltetekDarab++;
                    }
                }
                for (int i = 0; i < feltetKategoria3.Length; i++)
                {
                    if (valasztottFeltet == feltetKategoria3[i])
                    {
                        teljesAr += feltetKategoria3Ar;
                        feltetekDarab++;
                    }
                }
            }

            Console.WriteLine("A pizzára {0}db feltét került, a teljes ár {1}Ft", feltetekDarab, teljesAr);

            Console.ReadLine();
        }
    }
}
