using Microsoft.VisualStudio.TestTools.UnitTesting;
using WielkieKino.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WielkieKino.Logic.Tests
{
    [TestClass()]
    public class DataProcessingTests
    {
        [TestMethod()]
        public void WybierzFilmyZGatunkuTest()
        {
            string gatunek = "Fantasy";
            DataProcessing dp = new DataProcessing();
            var result = dp.WybierzFilmyZGatunku(Dane.SkladDanych.Filmy, "Fantasy");
            Assert.AreEqual("Konan Destylator", result[0]);
        }

        [TestMethod()]
        public void PodajCalkowiteWplywyZBiletowTest()
        {
            DataProcessing dp = new DataProcessing();
            var result = dp.PodajCalkowiteWplywyZBiletow(Dane.SkladDanych.Bilety);
            Assert.AreEqual(400.0, result);
        }

        [TestMethod()]
        public void WybierzFilmyPokazywaneDanegoDniaTest()
        {
            DataProcessing dp = new DataProcessing();
            var result = dp.WybierzFilmyPokazywaneDanegoDnia(Dane.SkladDanych.Seanse,
                new DateTime(2019, 01, 20));
            Assert.AreEqual(7, result.Count);
        }

        [TestMethod()]
        public void NajpopularniejszyGatunekTest()
        {
            DataProcessing dp = new DataProcessing();
            var result = dp.NajpopularniejszyGatunek(Dane.SkladDanych.Filmy);
            Assert.AreEqual("Obyczajowy", result);
        }

        [TestMethod()]
        public void ZwrocSalePosortowanePoCalkowitejLiczbieMiejscTest()
        {
            DataProcessing dp = new DataProcessing();
            var result = dp.ZwrocSalePosortowanePoCalkowitejLiczbieMiejsc(Dane.SkladDanych.Sale);
            Assert.AreEqual("Kameralna", result[0].Nazwa);
            Assert.AreEqual("Wisła", result[2].Nazwa);
        }

        [TestMethod()]
        public void ZwrocSaleGdzieJestNajwiecejSeansowTest()
        {
            DataProcessing dp = new DataProcessing();
            var result = dp.ZwrocSaleGdzieJestNajwiecejSeansow(Dane.SkladDanych.Seanse,
                new DateTime(2019, 01, 20));
            Assert.AreEqual("Wisła", result.Nazwa);
        }

        [TestMethod()]
        public void ZwrocFilmNaKtorySprzedanoNajwiecejBiletowTest()
        {
            DataProcessing dp = new DataProcessing();
            var result = dp.ZwrocFilmNaKtorySprzedanoNajwiecejBiletow(Dane.SkladDanych.Filmy,
                Dane.SkladDanych.Bilety);
            Assert.AreEqual("Konan Destylator", result.Tytul);
        }

        [TestMethod()]
        public void PosortujFilmyPoDochodachTest()
        {
            DataProcessing dp = new DataProcessing();
            var result = dp.PosortujFilmyPoDochodach(Dane.SkladDanych.Filmy,
                Dane.SkladDanych.Bilety);
            Assert.AreEqual("Konan Destylator", result[0].Tytul);
            Assert.AreEqual("7 minut w Tybecie", result[2].Tytul);
        }
    }
}