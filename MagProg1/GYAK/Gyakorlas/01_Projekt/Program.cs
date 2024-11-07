using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Projekt
{
    internal class Program
    {
        const int FelnottKedvezmenyNelkul = 3800;
        const int Esti = 1800;
        const int VarosKartyas = 1500;
        const int DiakNyugdijas = 1000;

        const int Csaladi2Felnott1Gyerek = 9700;
        const int Csaladi2Felnott2Gyerek = 12100;
        const int GyerekExtra = 2400;

        static void Main(string[] args)
        {
            int jegyÁr = 0;
            Console.Write("Milyen jegyet szeretne vásárolni (egyéni/családi)?");
            string jegytípus = Console.ReadLine().ToLower().Trim();

            if (jegytípus == "egyéni")
            {
                Console.WriteLine("Van-e valamilyen kedvezményre jogosultsága?");
                string jogosultKedvezmenyre = Console.ReadLine();
                if (jogosultKedvezmenyre == "igen")
                {
                    Console.WriteLine("Milyen típusú kedvezménye van (városkártya/diák/nyugdíjas)?");
                    string kedvezmenyTipus = Console.ReadLine();
                    switch (kedvezmenyTipus)
                    {
                        case "városkártya":
                            jegyÁr = VarosKartyas;
                            break;
                        case "diák":
                            jegyÁr = DiakNyugdijas;
                            break;
                        case "nyugdíjas":
                            jegyÁr = DiakNyugdijas;
                            break;
                    }
                }
                else
                {
                    int ido;
                    do
                    {
                        Console.WriteLine("Hány óra van?");
                    } while (int.TryParse(Console.ReadLine(), out ido) && !(9 <= ido && ido <= 19));

                    if (ido >= 16)
                    {
                        jegyÁr = Esti;
                    }
                    else
                    {
                        jegyÁr = FelnottKedvezmenyNelkul;
                    }
                }
            }
            else if (jegytípus == "családi")
            {
                int gyerekekSzama;
                do
                {
                    Console.WriteLine("Adja meg a gyerekek számát!");
                } while (int.TryParse(Console.ReadLine(), out gyerekekSzama) && !(1 <= gyerekekSzama && gyerekekSzama <= 69));
                if (gyerekekSzama < 2)
                {
                    jegyÁr = Csaladi2Felnott1Gyerek;
                }
                else if (gyerekekSzama < 3)
                {
                    jegyÁr = Csaladi2Felnott2Gyerek;
                }
                else
                {
                    jegyÁr = Csaladi2Felnott2Gyerek + (gyerekekSzama - 2) * GyerekExtra;
                }

            }
            Console.WriteLine("A fizetendő jegyár: {0}", jegyÁr);
            Console.Read();
        }
    }
}
