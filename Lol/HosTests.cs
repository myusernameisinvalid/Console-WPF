using Microsoft.VisualStudio.TestTools.UnitTesting;
using LolCLI_V2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolCLI_V2.Tests
{
    [TestClass()]
    public class HosTests
    {
        /*Készítsen 4 tesztet a létrehozott függvényhez az alábbi hőssel:
        Parzival;a mágányos Hős;Fighter;A cél a kulcs! A cél a tojás!;500;100
        Tesztesetek: 10 szint 1400 HP, 1 szint 500 HP, 5 szint 900 HP, 18 szint 2200 HP
        */
        [TestMethod()]
        public void HpErtekTest()
        {
            string tesztAdat = "Parzival;a mágányos Hős;Fighter;A cél a kulcs! A cél a tojás!;500;100";
            Hos parzival = new Hos(tesztAdat);
            Assert.AreEqual(1400, parzival.HpErtek(10));
            Assert.AreEqual(500, parzival.HpErtek(1));
            Assert.AreEqual(900, parzival.HpErtek(5));
            Assert.AreEqual(2200, parzival.HpErtek(18));
        }
    }
}