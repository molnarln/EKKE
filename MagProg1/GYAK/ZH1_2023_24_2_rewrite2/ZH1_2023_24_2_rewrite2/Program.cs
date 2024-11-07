using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace ZH1_2023_24_2_rewrite2
{
    internal class Program
    {
        static int dobozAr = 100;
        static int kapacitas = 120;

        static string[] kategoria1 = new string[] { "ét", "tej", "fehér" };
        static string[] kategoria2 = new string[] { "mogyorós", "diós" };
        static string[] kategoria3 = new string[] { "szilvás", "pisztáciás", "nugátos", "ananászos" };

        static int kategória1Tomeg = 10;
        static int kategória2Tomeg = 20;
        static int kategória3Tomeg = 30;

        static int kategória1Ar = 150;
        static int kategória2Ar = 200;
        static int kategória3Ar = 300;

        static void Main(string[] args)
        {
            string kovetkezoCsoki = string.Empty;
            int csokoladeOssztomeg = 0;
            int csokoladeOsszErtek = 0;

            while (kovetkezoCsoki != "végeztem".ToLower().Trim())
            {
                Console.Write("Adja meg a következő csokoládét: ");
                kovetkezoCsoki = Console.ReadLine();

                for (int i = 0; i < kategoria1.Length; i++)
                {
                    if (kovetkezoCsoki == kategoria1[i])
                    {
                        csokoladeOssztomeg += kategória1Tomeg;
                        csokoladeOsszErtek += kategória1Ar;
                        break;
                    }
                }
                for (int i = 0; i < kategoria2.Length; i++)
                {
                    if (kovetkezoCsoki == kategoria2[i])
                    {
                        csokoladeOssztomeg += kategória2Tomeg;
                        csokoladeOsszErtek += kategória2Ar;
                        break;
                    }
                }
                for (int i = 0; i < kategoria3.Length; i++)
                {
                    if (kovetkezoCsoki == kategoria3[i])
                    {
                        csokoladeOssztomeg += kategória3Tomeg;
                        csokoladeOsszErtek += kategória3Ar;
                        break;
                    }
                }
            }

            int megkezdettDobozok = (int)Math.Ceiling((double)csokoladeOssztomeg / kapacitas);

            Console.WriteLine("A megkezdett dobozok száma: {0}, a fizetendő végösszeg: {1}", megkezdettDobozok, csokoladeOsszErtek + dobozAr * megkezdettDobozok);

            Console.ReadLine();
        }
    }
}
