using Microsoft.VisualStudio.TestTools.UnitTesting;
using csudh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csudh.Tests
{
    [TestClass()]
    public class SzerverTests
    {
        //Készítsen tesztet a függvényhez! A teszt vizsgáljon hibás és nem hibás eredményeket is!
        [TestMethod()]
        public void DomainTest()
        {
            Szerver tesztAdat = new Szerver("dhvx.csudh.edu;155.135.1.2");
            string elsoszint = tesztAdat.Domain(1);
            string masodikszint = tesztAdat.Domain(2);
            string harmadikszint = tesztAdat.Domain(3);

            Assert.AreEqual("edu", elsoszint);
            Assert.AreEqual("csudh", masodikszint);
            Assert.AreEqual("dhvx", harmadikszint);
        }
        [TestMethod()]
        public void DomainTest2() 
        {
            Szerver tesztSzerver = new Szerver("dhvx20.csudh.edu;155.135.1.1");
            string negyedikSzint = tesztSzerver.Domain(4);
            string otodikSzint = tesztSzerver.Domain(5);

            Assert.AreEqual("Nincs", negyedikSzint);
            Assert.AreEqual("Nincs", otodikSzint);
        }

    }
}