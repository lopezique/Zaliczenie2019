using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WielkieKino.Lib;

namespace WielkieKino.Dane
{
    /// <summary>
    /// Metody do implementacji (raczej) bez wykorzystania LINQ
    /// </summary>
    public class MetodyPomocnicze
    {
        /// <summary>
        /// Sprawdzenie czy dane miejsce w konkretnym seansie nie jest zajęte
        /// </summary>
        /// <param name="sprzedaneBilety"></param>
        /// <param name="seans"></param>
        /// <param name="rzad"></param>
        /// <param name="miejsce"></param>
        /// <returns></returns>
        public bool CzyMoznaKupicBilet(List<Bilet> sprzedaneBilety, Seans seans, int rzad, int miejsce)
        {
            foreach (Bilet bilet in sprzedaneBilety)
            {
                if (bilet.Seans == seans
                    && bilet.Rzad == rzad
                    && bilet.Miejsce == miejsce)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Sprawdzenie czy można projekcja filmu o zadanej godzinie nie nakłada się z już
        /// dodanymi seansami w tej sali.
        /// </summary>
        /// <param name="aktualneSeanse"></param>
        /// <param name="sala"></param>
        /// <param name="film"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool CzyMoznaDodacSeans(List<Seans> aktualneSeanse, Sala sala, Film film, DateTime data)
        {
            // np. nie można zagrać filmu "Egzamin" w sali Kameralnej 2019-01-20 o 17:00
            // można natomiast zagrać "Egzamin" w tej sali 2019-01-20 o 14:00
            foreach (Seans seans in aktualneSeanse)
            {
                
                if (seans.Sala == sala) {
                    // film nie może się zacząć w trakcie już dodanego seansu
                    if (seans.Date.Ticks <= data.Ticks
                        && seans.Date.AddMinutes(seans.Film.CzasTrwania).Ticks >= data.Ticks)
                        return false;
                    
                    // film nie może się skończyć w trakcie już dodanego seansu
                    if (seans.Date.AddMinutes(seans.Film.CzasTrwania).Ticks >= data.Date.Ticks
                    && seans.Date.AddMinutes(seans.Film.CzasTrwania).Ticks <= data.Date.AddMinutes(film.CzasTrwania).Ticks)
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sprzedaneBilety">wszystkie sprzedane bilety</param>
        /// <param name="seansDoSprawdzenia"></param>
        /// <returns></returns>
        public int LiczbaWolnychMiejscWSali(List<Bilet> sprzedaneBilety, Seans seansDoSprawdzenia)
        {
            // Właściwa odpowiedź: np. na pierwszy seans z listy seansów w klasie SkladDanych są 72 miejsca
            int zajete = 0;
            foreach (var item in sprzedaneBilety)
            {
                if (item.Seans == seansDoSprawdzenia)
                    zajete++;
            }
            Sala s = seansDoSprawdzenia.Sala;
            return s.LiczbaMiejscWRzedzie * s.LiczbaRzedow - zajete;
        }

        public double CalkowitePrzychodyZBiletow(List<Bilet> sprzedaneBilety)
        {
            // Właściwa odpowiedź: 400.00
            double przychody = 0.0;
            foreach (var item in sprzedaneBilety)
            {
                przychody += item.Cena;
            }
            return przychody;
        }
    }
}
