using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZTEES
{
    internal class Program
    {
        //2. feladat
        static int F2_Telitettseg(Vizsga vizsga)
        {
            return Convert.ToInt32(((double)vizsga.JelentkezettekSzama / vizsga.MaxLetszam) * 100);
        }

        //5.feladat
        static bool F5_AdottTargyhozTartozoAdottVizsga(Vizsga vizsga, string targyNev, bool irasbeli, string tagozat)
        {
            if (vizsga.TargyNev == targyNev && vizsga.Irasbeli == irasbeli && tagozat[0] == vizsga.TargyKod.ToLower()[0])
            {
                return true;
            }
            return false;
        }

        //7.feladat
        static List<string> F7_TargyNevek(List<Vizsga> vizsgak)
        {
            List<string> targynevek = new List<string>();

            foreach (Vizsga vizsga in vizsgak)
            {
                if (!targynevek.Contains(vizsga.TargyNev))
                {
                    targynevek.Add(vizsga.TargyNev);
                }
            }
            targynevek.Sort();
            targynevek.Reverse();

            return targynevek;
        }

        static void Main(string[] args)
        {
            List<Vizsga> vizsgak = new List<Vizsga>();
            StreamReader sr = new StreamReader("MP1_2024_25_ZH2_input.csv");

            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                Vizsga vizsga = new Vizsga();
                string[] adatok = sr.ReadLine().Split(';');

                vizsga.TargyKod = adatok[0];
                vizsga.TargyNev = adatok[1];
                vizsga.Irasbeli = adatok[2] == "I";
                vizsga.Idopont = DateTime.Parse(adatok[3]);
                vizsga.MaxLetszam = int.Parse(adatok[4]);
                vizsga.JelentkezettekSzama = int.Parse(adatok[5]);
                vizsga.Terem = adatok[6];

                vizsgak.Add(vizsga);
            }
            sr.Close();

            Console.WriteLine("December elejei 70% fölötti vizsgák:");

            //3.feladat
            int osszTelitettseg = 0;
            int vizsgaDarab = 0;
            foreach (Vizsga vizsga in vizsgak)
            {
                if (DateTime.Now.Date > vizsga.Idopont.Date && F2_Telitettseg(vizsga) > 70)
                {
                    Console.WriteLine($"{vizsga.Idopont:MMMM dd. hh:mm} - {vizsga.TargyKod} - {vizsga.TargyNev} ({(vizsga.Irasbeli ? "Írásbeli" : "Szóbeli")}) - {vizsga.JelentkezettekSzama}/{vizsga.MaxLetszam} ({F2_Telitettseg(vizsga)}%)");
                    osszTelitettseg += F2_Telitettseg(vizsga);
                    vizsgaDarab++;
                }
            }
            Console.WriteLine($"Ezen vizsgák átlagos átlagos telítettsége {(double)osszTelitettseg / vizsgaDarab:0.00}%.");

            //4.feladat

            Vizsga utolsoBEteltMagasszintuProgvizsga = new Vizsga();
            Vizsga utolsoBteltGrafikaVizsga = new Vizsga();
            foreach (Vizsga vizsga in vizsgak)
            {
                if (F2_Telitettseg(vizsga) == 100 && vizsga.TargyNev == "Magasszintű programozási nyelvek I" && utolsoBEteltMagasszintuProgvizsga.Idopont < vizsga.Idopont)
                {
                    utolsoBEteltMagasszintuProgvizsga = vizsga;
                }
                if (F2_Telitettseg(vizsga) == 100 && vizsga.TargyNev == "Bevezetés a számítógépi grafikába" && utolsoBteltGrafikaVizsga.Idopont < vizsga.Idopont)
                {
                    utolsoBteltGrafikaVizsga = vizsga;
                }
            }
            Console.WriteLine($"{utolsoBEteltMagasszintuProgvizsga.Idopont:MMMM dd. hh:mm} - {utolsoBEteltMagasszintuProgvizsga.TargyNev} - {utolsoBEteltMagasszintuProgvizsga.JelentkezettekSzama} fő");
            Console.WriteLine($"{utolsoBteltGrafikaVizsga.Idopont:MMMM dd. hh:mm} - {utolsoBteltGrafikaVizsga.TargyNev} - {utolsoBteltGrafikaVizsga.JelentkezettekSzama} fő");
            Console.WriteLine($"A {(utolsoBEteltMagasszintuProgvizsga.JelentkezettekSzama > utolsoBteltGrafikaVizsga.JelentkezettekSzama ? "Magasszintű programozási nyelvek I" : "Bevezetés a számítógépi grafikába")} 1 vizsgán többen vannak.");

            //6.feladat
            Console.Write("Adja meg a tárgy címét: ");
            string targyNev = Console.ReadLine();

            Console.Write("Adja meg a vizsga típusát (írásbeli/szóbeli): ");
            string vizsgaTipus = Console.ReadLine();
            bool irasbeli = vizsgaTipus == "írásbeli";

            Console.Write("Adja meg a tagozatot (nappali/levelező/távoktatás): ");
            string tagozat = Console.ReadLine();

            Console.WriteLine("Tantárgy:{0}", targyNev);
            Console.WriteLine("Vizsga típusa{0}", vizsgaTipus);
            Console.WriteLine("Tagozat:{0}", tagozat);
            Console.WriteLine("Az Ön számára javasolt vizsgák:");

            foreach (Vizsga vizsga in vizsgak)
            {
                if (F5_AdottTargyhozTartozoAdottVizsga(vizsga, targyNev, irasbeli, tagozat) && vizsga.Idopont > DateTime.Now && F2_Telitettseg(vizsga) < 100)
                {
                    Console.WriteLine($"{vizsga.Idopont:yyy MM dd. hh:mm} - {vizsga.JelentkezettekSzama}/{vizsga.MaxLetszam} ({vizsga.Terem})");
                }
            }

            //8.feladat
            List<string> targyak = F7_TargyNevek(vizsgak);

            foreach (string targy in targyak)
            {
                Vizsga vizsgaMaxLetszam = new Vizsga();
                int vizsgaPerTargy = 0;
                foreach (Vizsga vizsga in vizsgak)
                {
                    vizsgaPerTargy++;
                    if (vizsga.TargyNev == targy && vizsga.JelentkezettekSzama > vizsgaMaxLetszam.JelentkezettekSzama && vizsga.MaxLetszam > 10)
                    {
                        vizsgaMaxLetszam = vizsga;
                    }
                }
                Console.WriteLine($"{targy}: {vizsgaMaxLetszam.Idopont:yyy MM dd. hh:mm}, {vizsgaMaxLetszam.JelentkezettekSzama} fő, {vizsgaMaxLetszam.Terem}");
            }


            //Extra
            Console.WriteLine("\n\bVizsgák egy időpontban és teremben: ");
            List<Vizsga> duplikatumok = new List<Vizsga>();
            for (int i = 0; i < vizsgak.Count; i++)
            {
                for (int j = 0; j < vizsgak.Count; j++)
                {
                    if (i!=j && vizsgak[i].Idopont == vizsgak[j].Idopont && vizsgak[i].Terem == vizsgak[j].Terem)
                    {
                        duplikatumok.Add(vizsgak[j]);
                    }
                }
            }
            

            foreach (Vizsga vizsga in duplikatumok)
            {
                Console.WriteLine($"{vizsga.TargyNev} - {vizsga.Idopont:yyyy MM dd. hh:mm} - ({vizsga.Terem})");
            }
                
            Console.ReadLine();
        }
    }
}
