using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace ZH2_2021_22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Film> filmek = new List<Film>();
            StreamReader sr = new StreamReader("Filmek.csv", Encoding.Default);

            while (!sr.EndOfStream)
            {
                Film film = new Film();
                string sor = sr.ReadLine();
                string[] adatok = sor.Split(';');
                film.Rendezo = adatok[0];
                film.Cim = adatok[1];
                film.PremierDatum = DateTime.Parse(string.Format("{0}.{1}.{2}", adatok[2], adatok[3], adatok[4]));
                film.Kategoria = adatok[5].Split(',');
                film.IMDBErtekeles = double.Parse(adatok[6]);
                film.Korhatar = int.Parse(adatok[7]);
                film.Feliratos = adatok[8] == "feliratos";

                filmek.Add(film);
            }
            sr.Close();

            Console.WriteLine("Az alábbi film(eknek) nem volt még premierje:");
            foreach (Film film in filmek)
            {
                if (film.PremierDatum > DateTime.Now)
                {
                    Console.WriteLine("{0} - {1} ({2:yyyy MMMM dd})", film.Rendezo, film.Cim, film.PremierDatum);
                }
            }

            Console.Write("Adja meg a kedvenc rendezőjének a nevét: ");
            string rendezo = Console.ReadLine();
            bool vanKedvencRendezotolFilm = VanAdottRendezonekFilmje(filmek, rendezo);
            if (!vanKedvencRendezotolFilm)
            {
                Console.WriteLine("Nincs ettől a rendezőtől film!");
            }
            else
            {
                foreach (Film film in filmek)
                {
                    if (film.Rendezo == rendezo)
                    {
                        Console.WriteLine("Film címe: {0}, megjelenés éve: {1}", film.Cim, film.PremierDatum.Year);
                    }
                }
            }

            List<Film> valogatottFilmek = new List<Film>();

            ListaKesziteseKategoriaAlapjan(filmek, valogatottFilmek, "sci-fi");
            foreach (Film film in valogatottFilmek)
            {
                Console.WriteLine("{0} - {1} ({2})", film.Rendezo, film.Cim, film.Feliratos ? "feliratos" : "szinkronos");
            }

            Console.Write("Adja meg a törölni kívánt film címét: ");
            string cimTorlendo = Console.ReadLine();
            Console.Write("Adja meg a törölni kívánt film rendezőjét: ");
            string rendezoTorlendo = Console.ReadLine();
            int indexTorlendo = -1;

            for (int i = 0; i < filmek.Count; i++)
            {
                if (filmek[i].Cim == cimTorlendo && filmek[i].Rendezo == rendezoTorlendo)
                {
                    indexTorlendo = i;
                }
            }
            if (indexTorlendo == -1)
            {
                Console.WriteLine("Nincs ilyen film!");
            }
            else
            {
                filmek.RemoveAt(indexTorlendo);
                Console.WriteLine("A {0} indexű film törlésre került!", indexTorlendo);
            }

            Console.Write("Legfiatalabb személy életkora: ");

            int minEletkor = int.Parse(Console.ReadLine());

            List<string> kedveltKategoriakTarsasagban = KedveltKategoriak();
            Console.Write("Lehet feliratos? ");
            bool feliratosIsLehet = Console.ReadLine() == "igen" ? true : false;

            foreach (Film film in filmek)
            {
                bool kategoriaStimmel = false;
                foreach (string kategoria in film.Kategoria)
                {
                    if (kedveltKategoriakTarsasagban.Contains(kategoria))
                    {
                        kategoriaStimmel = true;
                    }
                }
                if (!kategoriaStimmel)
                {
                    continue;
                }
                if (film.Korhatar >= minEletkor)
                {
                    continue;
                }
                if (feliratosIsLehet)
                {
                    Console.WriteLine("{0} - {1} ({2})", film.Rendezo, film.Cim, film.Feliratos ? "feliratos" : "szinkronos");
                }
                else if (!film.Feliratos)
                {
                    Console.WriteLine("{0} - {1} ({2})", film.Rendezo, film.Cim, film.Feliratos ? "feliratos" : "szinkronos");

                }
            }

            List<string> mindenKategoria = new List<string>();
            foreach (Film film in filmek)
            {
                foreach (string kategoria in film.Kategoria)
                {
                    if (!mindenKategoria.Contains(kategoria))
                    {
                        mindenKategoria.Add(kategoria);
                    }
                }
            }

            foreach (string kategoria in mindenKategoria)
            {
                Film maxIMDBFilm = new Film();
                foreach (Film film in filmek)
                {
                    if (film.PremierDatum < DateTime.Now && film.Kategoria.Contains(kategoria))
                    {
                        if (maxIMDBFilm.IMDBErtekeles < film.IMDBErtekeles)
                        {
                            maxIMDBFilm = film;
                        }
                    }
                }
                Console.WriteLine("Kategória: {0}, max IMDB értékelés: {1}, film: {2}", kategoria, maxIMDBFilm.IMDBErtekeles, maxIMDBFilm.Cim);
            }
            Console.ReadLine();
        }

        public static bool VanAdottRendezonekFilmje(List<Film> filmek, string rendezo)
        {
            foreach (Film film in filmek)
            {
                if (film.Rendezo == rendezo)
                {
                    return true;
                }
            }
            return false;

        }

        public static void ListaKesziteseKategoriaAlapjan(List<Film> osszesFilm, List<Film> kategoriakFilmjei, string kategoria)
        {
            kategoriakFilmjei.Clear();
            foreach (Film film in osszesFilm)
            {
                if (film.Kategoria.Contains(kategoria))
                {
                    kategoriakFilmjei.Add(film);
                }
            }
        }

        public static List<string> KedveltKategoriak()
        {
            List<string> kedveltKategoriak = new List<string>();
            string kovetkezoKategoria = string.Empty;

            do
            {
                Console.Write("Adja meg a kedvelt kategóriát:");
                kovetkezoKategoria = Console.ReadLine();
                if (kovetkezoKategoria == "vége")
                {
                    break;
                }
                kedveltKategoriak.Add(kovetkezoKategoria);
            } while (kovetkezoKategoria != "vége");

            return kedveltKategoriak;
        }
    }
}
