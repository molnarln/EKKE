using HaztartasiGepek;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoProgram
{
    internal class Program
    {
        static void KuldemenyekRogzitese(HaztartasigepBolt bolt, string file)
        {
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(file);
                while (!sr.EndOfStream)
                {
                    string sor = sr.ReadLine();
                    string[] adatok = sor.Split(';');
                    try
                    {
                        Mosogep mosogep = new Mosogep(adatok[0],
                                                      adatok[1],
                                                      int.Parse(adatok[2]),
                                                      int.Parse(adatok[3]));
                        bolt.Elment(mosogep);

                    }
                    catch (NagyMaximalisToltotomegException)
                    {

                        Console.WriteLine("Túl nagy maximális töltőtömeg!");
                    }
                    catch (MaximalisFordulatszamNemErvenyesException ex)
                    {
                        Console.WriteLine("Érvénytelen maximális fordulatszám!");
                        try
                        {
                            Mosogep mg = new Mosogep(ex.Gyarto, ex.Tipus, ex.MaxToltoTomeg, (ex.Ervenytelenfordulatszam / 100) * 100);
                            bolt.Elment(mg);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Újabb hiba adódott.");
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Általános hiba történt");
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Fájl nem található. {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba történt: {ex.Message}");
            }
            finally
            {
                if (!(sr is null)) sr.Close();
            }
        }


        static void Main(string[] args)
        {
            HaztartasigepBolt bolt = new HaztartasigepBolt();
            KuldemenyekRogzitese(bolt, "mosogepek.csv");

            foreach (var item in bolt)
            {
                Console.WriteLine(item.ToString());
            }

            foreach (var item in bolt.NepszeruNagyGepek)
            {
                Console.WriteLine(item.ToString());
            }

            foreach (var item in bolt.HaromLegrelevansabbPhilipsMosogepLegalabb1100AsFordulattal)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine($"Van olyan LG, aminek a max fordulata nagyobb, mint 1000? {bolt.VanOlyanAmi(_ => _.MaxFordulat >= 1000 && _.Gyarto.Nev == "LG")}");

            Console.WriteLine($"{bolt[2].VizFelhasznalas(MosogepProgram.ECO, 3.3)}");

            Console.ReadLine();
        }
    }
}
