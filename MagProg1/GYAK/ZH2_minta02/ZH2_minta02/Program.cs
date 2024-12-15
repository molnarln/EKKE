using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ZH2_minta02
{

    internal class Program
    {
        //3. feladat
        public static bool F3_VanAdottGyartoEsIzesites(List<Csoki> csokik, string gyarto, string izesites)
        {
            foreach (Csoki csoki in csokik)
            {
                if (csoki.Marka == gyarto && csoki.Izesites == izesites)
                {
                    return true;
                }
            }
            return false;
        }

        //5. feladat
        public static void F5_AdottOsszegnelDragabbCsokik(List<Csoki> osszesCsoki, List<Csoki> eredmenyLista, int arHatar)
        {
            eredmenyLista.Clear();

            foreach (Csoki csoki in osszesCsoki)
            {
                if (csoki.Ar > arHatar)
                {
                    eredmenyLista.Add(csoki);
                }
            }
        }

        //6. feladat
        public static int F6_KedvezmenyesArSzamitas(Csoki csoki)
        {
            double kedvezmenyesAr;
            if (csoki.Szavatossag < DateTime.Parse("2022.05.01"))
            {
                return 0;
            }
            if (csoki.Tejcsoki)
            {
                kedvezmenyesAr = csoki.Ar * 0.85;
            }
            else
            {
                kedvezmenyesAr = csoki.Ar * 0.7;
            }
            if (csoki.RaktarKeszlet >= 60)
            {
                kedvezmenyesAr *= 0.94;
            }
            return Convert.ToInt32(kedvezmenyesAr);
        }

        static void Main(string[] args)
        {
            List<Csoki> csokik = new List<Csoki>();
            StreamReader sr = new StreamReader("MP1_ZH2_minta02_csokiraktar.csv");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string[] adatok = sr.ReadLine().Split(';');

                Csoki csoki = new Csoki();

                csoki.Azonosito = adatok[0];
                csoki.Marka = adatok[1];
                csoki.Tejcsoki = adatok[2] == "tej";
                csoki.Izesites = adatok[3];
                csoki.Szavatossag = DateTime.Parse(adatok[4]);
                csoki.Ar = int.Parse(adatok[5]);
                csoki.Tomeg = int.Parse(adatok[6]);
                csoki.RaktarKeszlet = int.Parse(adatok[7]);

                csokik.Add(csoki);
            }
            sr.Close();
            int lejartCsokiOssztomegGramm = 0;

            //2. Feladat
            foreach (Csoki csoki in csokik)
            {
                if (csoki.Szavatossag < DateTime.Now && csoki.RaktarKeszlet > 0)
                {
                    Console.WriteLine($"{csoki.Azonosito} : {csoki.Marka} - {csoki.Izesites} ({(csoki.Tejcsoki ? "tej" : "ét")}) ({csoki.Szavatossag:yyyy MMMM dd})");
                    lejartCsokiOssztomegGramm += csoki.Tomeg;
                }
            }
            Console.WriteLine($"Ezek megsemmisítésével {(double)lejartCsokiOssztomegGramm / 1000:0.00} kg csokoládé kerül ki a raktárból.");

            //4. Feladat
            Console.Write("Adja meg a gyártót: ");
            string gyarto = Console.ReadLine();

            Console.Write("Adja meg az izesitést: ");
            string izesites = Console.ReadLine();
            if (!F3_VanAdottGyartoEsIzesites(csokik, gyarto, izesites))
            {
                Console.WriteLine("Nincs ilyen csokoládé raktáron!");
            }
            else
            {
                Console.WriteLine("\nAz alábbi csokoládék felelnek meg a keresési feltételeknek:");
                foreach (Csoki csoki in csokik)
                {
                    if (csoki.Marka == gyarto && csoki.Izesites == izesites)
                    {
                        Console.WriteLine($"{csoki.Azonosito} - {csoki.Tomeg} gramm - {csoki.Ar} Ft - {(csoki.RaktarKeszlet > 0 ? "van raktáron" : "nincs raktáron")}");
                    }
                }
            }

            //7. feladat
            List<Csoki> HatOtvennelDragabbCsokik = new List<Csoki>();
            F5_AdottOsszegnelDragabbCsokik(csokik, HatOtvennelDragabbCsokik, 650);

            foreach (Csoki csoki in HatOtvennelDragabbCsokik)
            {
                if (csoki.Szavatossag >= DateTime.Parse("2022.05.01"))
                {
                    Console.WriteLine($"{csoki.Azonosito} : {csoki.Marka} ({csoki.Izesites}) Ár : {csoki.Ar} Ft, Akciós ár : {F6_KedvezmenyesArSzamitas(csoki)} Ft");
                }
            }


            //8. feladat
            int indexTorlendo = -1;
            for (int i = 0; i < csokik.Count; i++)
            {
                if (csokik[i].Azonosito == "NBKL5NQ")
                {
                    indexTorlendo = i;
                }
            }
            csokik.RemoveAt(indexTorlendo);
            Console.WriteLine("Az {0} indexű csoki törlésre került.", indexTorlendo);

            List<string> gyartok = new List<string>();

            foreach (Csoki csoki in csokik)
            {
                if (!gyartok.Contains(csoki.Marka))
                {
                    gyartok.Add(csoki.Marka);
                }
            }


            int legmagasabbAruTermekekOsszerteke = 0;
            foreach (string gy in gyartok)
            {
                int legmagasabbArAdottGyartoEseten = int.MinValue;
                string izesitesLegmagasabbAruTermekIzesites = string.Empty;
                foreach (Csoki csoki in csokik)
                {
                    if (csoki.Marka == gy && csoki.Ar > legmagasabbArAdottGyartoEseten)
                    {
                        legmagasabbArAdottGyartoEseten = csoki.Ar;
                        izesitesLegmagasabbAruTermekIzesites = csoki.Izesites;
                    }
                }
                Console.WriteLine($"Legmagasabb árú {gy} termék ára: {legmagasabbArAdottGyartoEseten}, ízesítése: {izesitesLegmagasabbAruTermekIzesites}");
                legmagasabbAruTermekekOsszerteke += legmagasabbArAdottGyartoEseten;
            }
            Console.WriteLine("Legmagasabb árú termékek összértéke: {0}", legmagasabbAruTermekekOsszerteke);

            Console.ReadLine();
        }
    }
}
