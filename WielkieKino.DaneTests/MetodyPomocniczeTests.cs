using Microsoft.VisualStudio.TestTools.UnitTesting;
using WielkieKino.Dane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WielkieKino.Dane.Tests
{
    [TestClass()]
    public class MetodyPomocniczeTests
    {
        [TestMethod()]
        public void CzyMoznaKupicBiletTest()
        {
            MetodyPomocnicze mp = new MetodyPomocnicze();
            bool shouldBeFalse = mp.CzyMoznaKupicBilet(Dane.SkladDanych.Bilety,
                Dane.SkladDanych.Seanse[0], 6, 6);
            bool shouldBeOK = mp.CzyMoznaKupicBilet(Dane.SkladDanych.Bilety,
                Dane.SkladDanych.Seanse[0], 1, 1);
            Assert.IsFalse(shouldBeFalse);
            Assert.IsTrue(shouldBeOK);
        }

        [TestMethod()]
        public void CzyMoznaDodacSeansTest()
        {
            MetodyPomocnicze mp = new MetodyPomocnicze();
            bool resultEgzamin = mp.CzyMoznaDodacSeans(Dane.SkladDanych.Seanse,
                Dane.SkladDanych.Sale[2], Dane.SkladDanych.Filmy[2],
                new DateTime(2019, 01, 20, 17, 0, 0));
            bool resultEgzaminOK = mp.CzyMoznaDodacSeans(Dane.SkladDanych.Seanse,
                Dane.SkladDanych.Sale[2], Dane.SkladDanych.Filmy[2],
                new DateTime(2019, 01, 20, 14, 0, 0));
            Assert.IsFalse(resultEgzamin);
            Assert.IsTrue(resultEgzaminOK);
        }

        [TestMethod()]
        public void LiczbaWolnychMiejscWSaliTest()
        {
            MetodyPomocnicze mp = new MetodyPomocnicze();
            int wolneKonan = 
                mp.LiczbaWolnychMiejscWSali(Dane.SkladDanych.Bilety, 
                Dane.SkladDanych.Seanse[0]);
            Assert.AreEqual(72, wolneKonan);
        }

        [TestMethod()]
        public void CalkowitePrzychodyZBiletowTest()
        {
            MetodyPomocnicze mp = new MetodyPomocnicze();
            Assert.AreEqual(400.0, mp.CalkowitePrzychodyZBiletow(Dane.SkladDanych.Bilety));
        }
    }
}