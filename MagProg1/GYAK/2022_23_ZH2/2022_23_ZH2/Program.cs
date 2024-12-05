using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022_23_ZH2
{
    internal class Program
    {
        //3. feladat
        public static int F3_kedvezmenySzamitasa(Laptop laptop)
        {
            int ar = laptop.ar;
            if (laptop.beszerzesDatuma < DateTime.Parse("2022.10.01"))
            {
                ar = Convert.ToInt32(laptop.ar * 0.75);
            }
            if (laptop.tarhelyTipus == "HDD" || laptop.tarhelyTipus == "SSHD")
            {
                ar -= 12000;
            }
            if (laptop.kiallitasiDarab)
            {
                ar = Convert.ToInt32(laptop.ar * 0.85);
            }
            return ar;
        }

        //4. feladat
        public static bool F4_vanAdottTulajdonsaguLaptop(List<Laptop> laptopok, string gyartoNeve, string processzorTipusa)
        {
            foreach (Laptop laptop in laptopok)
            {
                if (laptop.gyarto == gyartoNeve && laptop.processzor == processzorTipusa)
                {
                    return true;
                }
            }
            return false;
        }

        //7. feladat
        public static List<string> F7_gyartok(List<Laptop> laptopok)
        {
            List<string> temp = new List<string>();
            foreach (Laptop laptop in laptopok)
            {
                if (!temp.Contains(laptop.gyarto))
                {
                    temp.Add(laptop.gyarto);
                }
            }
            temp.Sort();
            return temp;
        }

        static void Main(string[] args)
        {
            List<Laptop> laptopok = new List<Laptop>();
            StreamReader sr = new StreamReader("MP1_2022_23_ZH2_A_input.csv");

            sr.ReadLine();

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] adatok = line.Split(';');
                Laptop laptop = new Laptop();

                laptop.gyarto = adatok[0];
                laptop.processzor = adatok[1];
                laptop.beszerzesDatuma = DateTime.Parse(adatok[2]);
                laptop.GPU = adatok[3];
                laptop.RAM = int.Parse(adatok[4]);
                laptop.tarhely = int.Parse(adatok[5]);
                laptop.tarhelyTipus = adatok[6];
                laptop.kiallitasiDarab = adatok[7] == "igen";
                laptop.ar = int.Parse(adatok[8]);
                laptopok.Add(laptop);
            }
            sr.Close();

            Console.WriteLine("\n2. feladat");
            Console.WriteLine("A Black Friday alatt kitett laptopok:");

            int osszAr = 0;
            int darab = 0;
            foreach (Laptop laptop in laptopok)
            {
                if (laptop.beszerzesDatuma >= DateTime.Parse("2022.12.25") && laptop.beszerzesDatuma <= DateTime.Parse("2022.12.27"))
                {
                    Console.WriteLine($"{laptop.gyarto} - {laptop.processzor}, {laptop.RAM} GB, {laptop.tarhely} MB {laptop.tarhelyTipus}, {laptop.GPU}");
                    osszAr += laptop.ar;
                    darab++;
                }

            }
            Console.WriteLine($"A fenti laptopok átlagos ára {Convert.ToInt32((double)osszAr / darab)} Ft.");

            Console.WriteLine("\n5. feladat");

            Console.Write("Adja meg a gyártót:");
            string gyarto = Console.ReadLine();
            Console.Write("Adja meg a processzort:");
            string processzor = Console.ReadLine();

            if (!F4_vanAdottTulajdonsaguLaptop(laptopok, gyarto, processzor))
            {
                Console.WriteLine("Nincs a feltételeknek megfelelő laptop!");
            }
            else
            {
                Console.WriteLine($"Gyártó: {gyarto}");
                Console.WriteLine($"Processzor: {processzor}");

                foreach (Laptop laptop in laptopok)
                {
                    if (laptop.gyarto == gyarto && laptop.processzor == processzor)
                    {
                        Console.WriteLine($"{laptop.RAM} GB, {laptop.GPU}, Ár: {laptop.ar} Ft, Kedv. ár: {F3_kedvezmenySzamitasa(laptop)} Ft");
                    }
                }
            }

            //6.feladat

            foreach (Laptop laptop in laptopok)
            {
                if (laptop.RAM == 4)
                {
                    laptop.RAM = 8;
                    laptop.ar += 3000;
                }
            }

            Console.WriteLine("\n8. feladat");

            List<string> gyartok = F7_gyartok(laptopok);

            foreach (string gy in gyartok)
            {
                Laptop legmagasabbKedvezmenyesAru = new Laptop();

                foreach (Laptop laptop in laptopok)
                {
                    if (laptop.gyarto == gy && !laptop.kiallitasiDarab)
                    {
                        if (F3_kedvezmenySzamitasa(laptop) > F3_kedvezmenySzamitasa(legmagasabbKedvezmenyesAru))
                        {
                            legmagasabbKedvezmenyesAru = laptop;
                        }
                    }
                }

                Console.WriteLine($"{gy}: {legmagasabbKedvezmenyesAru.RAM} GB, {legmagasabbKedvezmenyesAru.GPU}, Kedv ár: {F3_kedvezmenySzamitasa(legmagasabbKedvezmenyesAru)} Ft");
            }
            Console.ReadLine();
        }
    }
}
