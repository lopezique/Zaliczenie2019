using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WielkieKino.Lib;

namespace WielkieKino.Dane
{
    public class SkladDanych
    {
        public static List<Sala> Sale { get; private set; }
        public static List<Film> Filmy { get; private set; }
        public static List<Seans> Seanse { get; private set; }
        public static List<Bilet> Bilety { get; private set; }

        static SkladDanych()
        {
            Sale = new List<Sala>();
            Sale.Add(new Sala() { Nazwa = "Bałtyk", LiczbaMiejscWRzedzie = 10, LiczbaRzedow = 8 });
            Sale.Add(new Sala() { Nazwa = "Wisła", LiczbaMiejscWRzedzie = 12, LiczbaRzedow = 10 });
            Sale.Add(new Sala() { Nazwa = "Kameralna", LiczbaMiejscWRzedzie = 5, LiczbaRzedow = 4 });

            Filmy = new List<Film>();
            Filmy.Add(new Film() { Tytul = "Konan Destylator", CzasTrwania = 90, Gatunek = "Fantasy" });
            Filmy.Add(new Film() { Tytul = "Lew, Czarownica i Stara Szafiarka", CzasTrwania = 100, Gatunek = "Dramat" });
            Filmy.Add(new Film() { Tytul = "Egzamin", CzasTrwania = 100, Gatunek = "Horror" });
            Filmy.Add(new Film() { Tytul = "7 minut w Tybecie", CzasTrwania = 7, Gatunek = "Obyczajowy" });
            Filmy.Add(new Film() { Tytul = "Przaśny Film", CzasTrwania = 95, Gatunek = "Obyczajowy" });

            Seanse = new List<Seans>();
            // sala "Bałtyk"
            Seanse.Add(
                new Seans()
                {
                    Date = new DateTime(2019, 1, 20, 12, 00, 00),
                    Film = Filmy[0],
                    Sala = Sale[0]
                });
            Seanse.Add(
                new Seans()
                {
                    Date = new DateTime(2019, 1, 20, 14, 00, 00),
                    Film = Filmy[1],
                    Sala = Sale[0]
                });

            //Sala "Wisła"
            Seanse.Add(
                new Seans()
                {
                    Date = new DateTime(2019, 1, 20, 12, 00, 00),
                    Film = Filmy[3],
                    Sala = Sale[1]
                });
            Seanse.Add(
                new Seans()
                {
                    Date = new DateTime(2019, 1, 20, 14, 00, 00),
                    Film = Filmy[0],
                    Sala = Sale[1]
                });
            Seanse.Add(
                new Seans()
                {
                    Date = new DateTime(2019, 1, 20, 16, 00, 00),
                    Film = Filmy[1],
                    Sala = Sale[1]
                });

            // Sala "Kameralna"
            Seanse.Add(
                new Seans()
                {
                    Date = new DateTime(2019, 1, 20, 12, 00, 00),
                    Film = Filmy[2],
                    Sala = Sale[2]
                });
            Seanse.Add(
                new Seans()
                {
                    Date = new DateTime(2019, 1, 20, 16, 00, 00),
                    Film = Filmy[0],
                    Sala = Sale[2]
                });

            Bilety = new List<Bilet>();
            Bilety.Add(new Bilet(Seanse[0], 20.00, 5, 5));
            Bilety.Add(new Bilet(Seanse[0], 20.00, 5, 6));
            Bilety.Add(new Bilet(Seanse[0], 20.00, 5, 7));
            Bilety.Add(new Bilet(Seanse[0], 20.00, 6, 5));
            Bilety.Add(new Bilet(Seanse[0], 20.00, 6, 6));
            Bilety.Add(new Bilet(Seanse[0], 20.00, 6, 7));
            Bilety.Add(new Bilet(Seanse[0], 20.00, 7, 6));
            Bilety.Add(new Bilet(Seanse[0], 20.00, 7, 7));

            Bilety.Add(new Bilet(Seanse[1], 22.00, 4, 5));
            Bilety.Add(new Bilet(Seanse[1], 22.00, 4, 6));
            Bilety.Add(new Bilet(Seanse[1], 22.00, 4, 7));
            Bilety.Add(new Bilet(Seanse[1], 22.00, 4, 5));
            Bilety.Add(new Bilet(Seanse[1], 22.00, 4, 6));
            Bilety.Add(new Bilet(Seanse[1], 22.00, 4, 7));

            Bilety.Add(new Bilet(Seanse[2], 18.00, 4, 5));
            Bilety.Add(new Bilet(Seanse[2], 18.00, 4, 6));
            Bilety.Add(new Bilet(Seanse[2], 18.00, 4, 7));
            Bilety.Add(new Bilet(Seanse[2], 18.00, 4, 5));
            Bilety.Add(new Bilet(Seanse[2], 18.00, 4, 6));
            Bilety.Add(new Bilet(Seanse[2], 18.00, 4, 7));
        }
    }
}
