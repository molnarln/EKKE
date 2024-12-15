using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace ZH2_minta01
{
    internal class Program
    {
        static DateTime maiDatumMock = DateTime.Parse("2021.01.01");

        //3.Feladat
        static bool F3_GyartoEsAllapotLekerdezes(List<Auto> autok, string Gyarto, string Allapot)
        {
            foreach (Auto auto in autok)
            {
                if (auto.Gyarto == Gyarto && auto.Allapot == Allapot)
                {
                    return true;
                }
            }
            return false;
        }

        //5.feladat
        static List<Auto> F5_AdottGyartoAutoi(List<Auto> autok, List<Auto> eredmenyLista, string Gyarto)
        {
            eredmenyLista.Clear();

            foreach (Auto auto in autok)
            {
                if (auto.Gyarto == Gyarto)
                {
                    eredmenyLista.Add(auto);
                }
            }
            return eredmenyLista;
        }

        //8.feladat
        static int F8_HirdetesiArSzamitasa(Auto auto)
        {
            double amortizacio = 0;
            int klimaFelar = 0;
            
            switch (auto.Allapot)
            {
                case "újszerű": amortizacio = 0.11; break;
                case "megkímélt": amortizacio = 0.2; break;
                case "sérült": amortizacio = 0.35; break;
                case "hibás": amortizacio = 0.42; break;
            }

            switch (auto.Klima)
            {
                case "nincs": klimaFelar = 0; break;
                case "manuális": klimaFelar = 120000; break;
                case "digitális": klimaFelar = 245000; break;
                case "digitális-többzónás": klimaFelar = 320000; break;
            }

            int eletkorEvekben = maiDatumMock.Year - auto.Evjarat;
            double becsultAr = auto.Ar * Math.Pow(amortizacio, eletkorEvekben) + klimaFelar;

            return Convert.ToInt32(becsultAr);
        }

        static void Main(string[] args)
        {

            StreamReader sr = new StreamReader("MP1_ZH2_minta01_autok.csv");
            sr.ReadLine();

            List<Auto> autok = new List<Auto>();

            while (!sr.EndOfStream)
            {
                string[] adatok = sr.ReadLine().Split(';');
                Auto auto = new Auto();

                auto.Rendszam = adatok[0];
                auto.ForgalmiErvenyesseg = DateTime.Parse(adatok[1]);
                auto.Gyarto = adatok[2];
                auto.Allapot = adatok[3];
                auto.Klima = adatok[4];
                auto.AutomataValto = adatok[5] == "automata";
                auto.Ar = int.Parse(adatok[6]);
                auto.Evjarat = int.Parse(adatok[7]);

                autok.Add(auto);
            }
            sr.Close();

            //2. feladat
            foreach (Auto auto in autok)
            {
                if (auto.ForgalmiErvenyesseg < maiDatumMock)
                {
                    Console.WriteLine($"{auto.Rendszam} - {auto.Gyarto} ({auto.ForgalmiErvenyesseg:yyyy MMMM dd})");
                }
            }

            //4. feladat

            Console.Write("Adja meg a gyártót: ");
            string gyarto = Console.ReadLine();
            Console.Write("Adja meg az állapotot: ");
            string allapot = Console.ReadLine();

            if (!F3_GyartoEsAllapotLekerdezes(autok, gyarto, allapot))
            {
                Console.WriteLine("Nincs a keresési feltételeknek megfelelő autó!");
            }
            else
            {
                foreach (Auto auto in autok)
                {
                    if (auto.Gyarto == gyarto && auto.Allapot == allapot)
                    {
                        Console.WriteLine($"{auto.Rendszam} - {(auto.AutomataValto ? "automata" : "manuális")} - {auto.Klima} - {auto.Ar}Ft");
                    }
                }
            }

            //6.feladat
            List<Auto> nissanLista = new List<Auto>();

            F5_AdottGyartoAutoi(autok, nissanLista, "Nissan");
            Console.WriteLine("\nNissan-ok");

            int osszAr = 0;
            int nissanDarab = 0;

            foreach (Auto auto in nissanLista)
            {
                Console.WriteLine($"{auto.Rendszam} - {auto.Allapot}, {(auto.AutomataValto ? "automata" : "manuális")} váltó, évjárat : {auto.Evjarat}");
                osszAr += auto.Ar;
                nissanDarab++;
            }
            Console.WriteLine("Az autók átlagos ára: {0:0.00}Ft.", (double)osszAr / nissanDarab);

            //7.feladat:

            Console.Write("Adja meg a törölni kívánt rendszámot: ");
            string rendszamTorlendo = Console.ReadLine().ToUpper();
            int rendszamTorlendoIndex = -1;

            for (int i = 0; i < autok.Count; i++)
            {
                if (autok[i].Rendszam == rendszamTorlendo)
                {
                    rendszamTorlendoIndex = i;
                }
            }
            if (rendszamTorlendoIndex == -1)
            {
                Console.WriteLine("Nincs ilyen rendszámú autó!");
            }
            else
            {
                autok.RemoveAt(rendszamTorlendoIndex);
            }

            //9.feladat

            List<string> gyartok = new List<string>();

            foreach (Auto auto in autok)
            {
                if (!gyartok.Contains(auto.Gyarto))
                {
                    gyartok.Add(auto.Gyarto);
                }
            }

            foreach (string gy in gyartok)
            {
                Auto legmagasabbHirdetesiAruAuto = new Auto();
                double legmagasabbHirdetesiAr;

                foreach (Auto auto in autok)
                {
                    if (auto.Gyarto == gy && F8_HirdetesiArSzamitasa(auto) > F8_HirdetesiArSzamitasa(legmagasabbHirdetesiAruAuto))
                    {
                        legmagasabbHirdetesiAruAuto = auto;
                    }
                }
                legmagasabbHirdetesiAr = F8_HirdetesiArSzamitasa(legmagasabbHirdetesiAruAuto);
                Console.WriteLine($"{legmagasabbHirdetesiAruAuto.Gyarto} - {F8_HirdetesiArSzamitasa(legmagasabbHirdetesiAruAuto)}Ft - {legmagasabbHirdetesiAruAuto.Rendszam}");
            }


            Console.ReadLine();
        }
    }
}
