using Microsoft.VisualStudio.TestTools.UnitTesting;
using Iskola;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iskola.Tests
{
    [TestClass()]
    public class TanuloTests
    {
        /*Készítsen tesztet a függvényhez!
        A teszt vizsgáljon hibás és nem hibás eredményeket is!
        (A teszt a jelenlegi adatok vizsgálatára szól, független a fájl tartalmától! Tehát nem kell
        vizsgálnia, ha megváltozik valakinek az osztálya stb…)
        Jó minta: Bodnar Szilvia →6cbodszi
        Krizsan Vivien Evelin →6ckriviv
        Rossz minta, bármi ami biztosan nem jó, tehát részben vagy egészében hibás átalakítás!
        */
        [TestMethod()]
        public void AzonositoTest()
        {
            string teszt1 = "6cbodszi";
            Tanulo tanulo1 = new Tanulo("2006;C;Bodnar Szilvia");
            Assert.AreEqual(teszt1, tanulo1.Azonosito());

            string teszt2 = "6ckriviv";
            Tanulo tanulo2 = new Tanulo("2006;C;Krizsan Vivien Evelin");
            Assert.AreEqual(teszt2, tanulo2.Azonosito());
        }
        [TestMethod()]
        public void AzonositoTest2()
        {
            string teszt3 = "6cbodszi";
            Tanulo tanulo1 = new Tanulo("2006;C;Bodnar Szilvia");
            Assert.AreNotEqual("6cbodsz", tanulo1.Azonosito());
        }
    }
}