using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WielkieKino.Lib;

namespace WielkieKino.Logic
{
    /// <summary>
    /// Metody do napisania z wykorzystaniem LINQ (w składni zapytania, wyrażeń
    /// lambda lub mieszanej)
    /// </summary>
    public class DataProcessing
    {
        public List<string> WybierzFilmyZGatunku(List<Film> filmy, string gatunek)
        {
            // Właściwa odpowiedź: np. "Konan Destylator" dla "Fantasy"
            return (from Film film in filmy
                    where film.Gatunek == gatunek
                    select film.Tytul).ToList();
        }

        /// <summary>
        /// Sumujemy wpływy bez względu na datę seansu
        /// </summary>
        /// <param name="bilety"></param>
        /// <returns></returns>
        public int PodajCalkowiteWplywyZBiletow(List<Bilet> bilety)
        {
            // Właściwa odpowiedź: 400
            return (int)bilety.Sum(bilet => bilet.Cena);
        }

        public List<Film> WybierzFilmyPokazywaneDanegoDnia(List<Seans> seanse, DateTime data)
        {
            return (from Seans s in seanse
                    where s.Date.Year == data.Year &&
                    s.Date.Month == data.Month &&
                    s.Date.Day == data.Day
                    select s.Film).ToList();
        }


        /// <summary>
        /// Zwraca gatunek, z którego jest najwięcej filmów. Jeśli jest kilka takich
        /// gatunków, to zwraca dowolny z nich.
        /// </summary>
        /// <param name="filmy"></param>
        /// <returns></returns>
        public string NajpopularniejszyGatunek(List<Film> filmy)
        {
            string result = filmy.GroupBy(f => f.Gatunek).
                OrderByDescending(group => group.Count()).First().Key;
            // Właściwa odpowiedź: Obyczajowy
            return result;
        }

        public List<Sala> ZwrocSalePosortowanePoCalkowitejLiczbieMiejsc(List<Sala> sale)
        {
            // Właściwa odpowiedź: Kameralna, Bałtyk, Wisła (lub w odwrotnej kolejności)

            return sale.OrderBy(s=>s.LiczbaMiejscWRzedzie * s.LiczbaRzedow).ToList();
        }

        public Sala ZwrocSaleGdzieJestNajwiecejSeansow(List<Seans> seanse, DateTime data)
        {
            // Właściwa odpowiedź dla daty 2019-01-20: sala "Wisła" 
            return seanse.Where(s => s.Date.ToShortDateString() == data.ToShortDateString())
                .GroupBy(s => s.Sala).OrderByDescending(gr => gr.Count()).First().Key;
            //return null;
        }

        /// <summary>
        /// Uwaga: Nie wszystkie parametry przekazane do metody muszą być użyte przy
        /// implementacji. Jeśli jest kilka takich filmów, zwracamy dowolny.
        /// </summary>
        /// <param name="filmy"></param>
        /// <param name="bilety"></param>
        /// <returns></returns>
        public Film ZwrocFilmNaKtorySprzedanoNajwiecejBiletow(List<Film> filmy, List<Bilet> bilety)
        {
            // Właściwa odpowiedź: "Konan Destylator"
            return bilety.GroupBy(bilet => bilet.Seans.Film).
                OrderByDescending(gr => gr.Count())
                .First().Key;
        }

        /// <summary>
        /// Uwaga: Nie wszystkie parametry metody muszą być wykorzystane przy
        /// implementacji. Filmy z takim samym przychodem zwracamy w dowolnej kolejności
        /// </summary>
        /// <param name="filmy"></param>
        /// <param name="bilety"></param>
        /// <returns></returns>
        
        //tu należało zmienić zwracany typ.
        //metoda w zasadzie identyczna jak poprzednio, tylko zmieniono formę zapisu
        public List<Film> PosortujFilmyPoDochodach(List<Film> filmy, List<Bilet> bilety)
        {
            Dictionary<Film, double> filmyZDochodami = new Dictionary<Film, double>();
            //tworzymy słownik filmów
            foreach (var item in filmy)
            {
                filmyZDochodami.Add(item, 0.0);
            }

            // zliczamy dochody filmów
            for (int i = 0; i < filmyZDochodami.Count; i++)
            { 
                Film f = filmyZDochodami.Keys.ElementAt(i);
                List<Bilet> biletyNaFilm = bilety.Where(bilet => bilet.Seans.Film == f).ToList();
                filmyZDochodami[f] = biletyNaFilm.Sum(
                    b => b.Cena);
            }

            // wybieramy najbardziej dochodowy film
            double maxProfit = filmyZDochodami.Values.Max();
            return filmyZDochodami.OrderByDescending(entry => entry.Value).
                Select(entry => entry.Key).ToList();
        }
    }
}
