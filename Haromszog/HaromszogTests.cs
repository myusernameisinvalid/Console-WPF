using Microsoft.VisualStudio.TestTools.UnitTesting;
using haromszogekCLI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace haromszogekCLI.Tests
{
    [TestClass()]
    public class HaromszogTests
    {
        [TestMethod()]
        public void derekszoguTest()
        {
            //A teszttel ellenőrizze le, hogy a=3 b=4 c=5 oldalaknál a függvény helyes(true) értékkel tér-e vissza!
            string tesztadat = "3 4 5";
            Haromszog tesztsor = new Haromszog(tesztadat);
            bool kapotteredmeny = tesztsor.derekszogu(3,4,5);
            Assert.IsTrue(kapotteredmeny);
        }
    }
}