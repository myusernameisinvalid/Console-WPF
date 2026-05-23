using Microsoft.VisualStudio.TestTools.UnitTesting;
using trapezCLI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace trapezCLI.Tests
{
    [TestClass()]
    public class TrapézTests
    {
        //Szerkeszthetőség ellenőrzése:Példa: a=1 b=1 c=1 d=4 m=4 esetén a függvény hamis értéket ad vissza.
        [TestMethod()]
        public void szerkeszthetoTest()
        {
            Trapéz t = new Trapéz("1 1 1 4 4");
            bool eredmeny = t.szerkesztheto();
            Assert.IsFalse(eredmeny);
        }

        //Derékszögű trapéz felismerése:Példa: a=3 b=4 c=5 d=6 m=6 esetén a függvény igaz értéket ad vissza.
        [TestMethod()]
        public void derekszoguTest()
        {
            Trapéz t = new Trapéz("3 4 5 6 6");
            bool eredmeny = t.derekszogu();
            Assert.IsTrue(eredmeny);
        }

        //Téglalap felismerése:Példa: a=5 b=5 c=5 d=5 m=5 esetén a függvény igaz értéket ad vissza.
        [TestMethod()]
        public void teglalapTest()
        {
            Trapéz t = new Trapéz("5 5 5 5 5");
            bool eredmeny = t.teglalap();
            Assert.IsTrue(eredmeny);
        }
    }
}