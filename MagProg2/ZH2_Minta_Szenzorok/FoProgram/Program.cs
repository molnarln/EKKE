using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZH2_Minta_Szenzorok;

namespace FoProgram
{
    internal class Program
    {
        static Random rnd = new Random();

        static void TelepitSzenzorHalozat(string input, SzenzorHalozat halozat)
        {
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(input);
                while (!sr.EndOfStream)
                {
                    string sor = sr.ReadLine();
                    string[] adatok = sor.Split(';');
                    try
                    {

                        Homero homero = new Homero(int.Parse(adatok[1]), int.Parse(adatok[2]),
                                                   int.Parse(adatok[3]), int.Parse(adatok[4]));
                        if (rnd.NextDouble() < 0.3)
                            homero.SetAktiv(false);
                        halozat.Telepit(homero);
                    }
                    catch (SzenzorInaktivException)
                    {

                        Console.WriteLine("Szenzor inaktív...");
                    }
                    catch (AlacsonyAlsoHatarException)
                    {
                        Console.WriteLine("Alacsony alsó határ...");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Általános hiba: {ex.StackTrace}");
                    }
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Hiba történt a fálj olvasásakor, exception: {ex.Message}");
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }
        }

        static void Main(string[] args)
        {
            SzenzorHalozat halozat = new SzenzorHalozat();
            TelepitSzenzorHalozat("szenzorok.csv", halozat);

            foreach (Szenzor szenzor in halozat)
            {
                Console.WriteLine(szenzor);
            }
            Console.ReadLine();
            Console.Clear();
            
            Console.WriteLine("Aktív szenzorok:\n");
            foreach (var item in halozat.AktivSzenzorok)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine($"Az aktív hőmérők x koordinátáinak átlaga: {halozat.AktivAtlag(_ => _.Pozicio.x)}");

            Console.ReadLine();
        }
    }
}
