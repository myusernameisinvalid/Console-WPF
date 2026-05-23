using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iskola
{
    public class Tanulo
    {
        public int KezdesEve { get;private set; }
        public string Osztaly { get; private set; }
        public string Nev { get; private set; }

        public Tanulo(string sor)
        {
            string[] adatok = sor.Split(';');
            this.KezdesEve = Convert.ToInt32(adatok[0]);
            this.Osztaly = adatok[1];
            this.Nev = adatok[2];
        }

        /*Az iskolai rendszergazdának egyedi azonosítókat kell készítenie a számítógép-hálózat
        használatához. Az azonosítókat a következő módon alakítja ki: első karaktere az évfolyam
        utolsó számjegye (pl.: 2006 esetén 6), következő karakter az osztály betűjele, majd a
        vezetékneve első három karaktere, végül első keresztneve első három karaktere következik.
        Az azonosítóban mindenütt kisbetűk szerepelnek. Feltételezhetjük, hogy a vezetéknév és az
        első keresztnév legalább 3 karakteres. Készítsen jellemzőt vagy függvényt, melyben
        meghatározza a rendelkezésre álló adatokból a tanuló azonosítóját!
        */
        public string Azonosito()
        {
            string ev = this.KezdesEve.ToString().Substring(3,1);
            string oszt = this.Osztaly;
            string[] nevek = this.Nev.Split(' ');
            string vezeteknev = nevek[0].Substring(0, 3);
            string keresztnev = nevek[1].Substring(0, 3);
            string teljesAzonosito = ev + oszt + vezeteknev + keresztnev;

            return teljesAzonosito.ToLower();
        }
    }
}