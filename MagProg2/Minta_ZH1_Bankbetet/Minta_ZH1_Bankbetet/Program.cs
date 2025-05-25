using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minta_ZH1_Bankbetet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Itt inicializálja a bankot!
            Bank bank = new Bank();
            bank.BankNeve = "Molnár László bankja";

            StreamReader sr = new StreamReader("bankbetetek.csv");
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] adatok = sor.Split(';');
                if (adatok[0] == "B")
                {
                    Bankbetet bb = new Bankbetet(adatok[1], int.Parse(adatok[2]), double.Parse(adatok[3]), int.Parse(adatok[4]));
                    bank.BankbetetHozzaadasa(bb);
                }
                else
                {
                    BefektetesiJegy befjegy = new BefektetesiJegy(adatok[1], int.Parse(adatok[2]), double.Parse(adatok[3]), int.Parse(adatok[4]), adatok[5], double.Parse(adatok[6]), double.Parse(adatok[7]), (Kockazat)Enum.Parse(typeof(Kockazat), adatok[8]));
                    bank.BankbetetHozzaadasa(befjegy);

                }
            }
            sr.Close();

            //Itt jelenítse meg az implementált lekérdezések eredményeit!

            foreach (var item in bank.BankbetetekMagasKezdotokevel)
            {
                Console.WriteLine(item.ToString() + "\n");
            }
            Console.ReadLine();
            Console.Clear();

            foreach (var item in bank.BefektetesiJegyekAdottHozamFelett(0.2))
            {
                Console.WriteLine(item.ToString() + "\n");

            }
            Console.ReadLine();
            Console.Clear();


            Console.ReadLine();
        }
    }
}
