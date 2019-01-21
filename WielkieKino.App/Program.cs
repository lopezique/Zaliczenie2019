using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WielkieKino.Lib;

namespace WielkieKino.App
{
    public class Program
    {
        /// <summary>
        /// Na podstawie danych seansu i sprzedanych biletów należy wyświetlić "podgląd"
        /// sali w ten sposób, że: każdy rząd to jedna linia tekstu, znaków w linii
        /// ma być tyle ile miejsc w rzędzie, miejsca zajęte są inaczej oznaczone niż
        /// miejsca wolne.
        /// </summary>
        /// <param name="sprzedaneBilety"></param>
        /// <param name="seans"></param>
        private static void WyswietlPodgladSali(List<Bilet> sprzedaneBilety, Seans seans)
        {
            int[,] podglad = new int[seans.Sala.LiczbaRzedow,seans.Sala.LiczbaMiejscWRzedzie];
            foreach (Bilet bilet in sprzedaneBilety)
            {
                if (bilet.Seans == seans)
                {
                    podglad[bilet.Rzad - 1, bilet.Miejsce - 1] = 1;
                }
            }

            for (int i = 0; i < seans.Sala.LiczbaRzedow; i++)
            {
                for (int j = 0; j < seans.Sala.LiczbaMiejscWRzedzie; j++)
                {
                    if (podglad[i, j] == 1)
                        Console.Write('o');
                    else
                        Console.Write('-');
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Wyświetlony powinien być tytuł filmu, godzina rozpoczęcia, czas trwania
        /// i nazwa sali.
        /// </summary>
        /// <param name="seanse"></param>
        /// <param name="data"></param>
        private static void WyswietlFilmyOGodzinie(List<Seans> seanse, DateTime data)
        {
            //Wskazówka: Do obliczenia czy parametr data "wpada" w film można wykorzystać
            //metodę AddMinutes wykonanej na czasie rozpoczęcia seansu.
            foreach (Seans seans in seanse)
            {
                if (seans.Date.Ticks <= data.Ticks
                    && seans.Date.AddMinutes(seans.Film.CzasTrwania).Ticks >= data.Ticks)
                    Console.WriteLine(seans.Film.Tytul + " " + seans.Date.ToShortTimeString() + " " +
                        seans.Film.CzasTrwania + " " + seans.Sala.Nazwa);
            }
        }

        public static void Main(string[] args)
        {
            WyswietlPodgladSali(Dane.SkladDanych.Bilety, Dane.SkladDanych.Seanse[0]);
            /* Przykładowo:
            ----------
            ----------
            ----------
            ----------
            ----ooo---
            ----ooo---
            -----oo---
            ----------
            */
            WyswietlFilmyOGodzinie(Dane.SkladDanych.Seanse, new DateTime(2019, 01, 20, 12, 0, 0));
            Console.ReadKey();
        }
    }
}
