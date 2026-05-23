using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csudh
{
    public class Szerver
    {
        public string Domaincim { get;private set; }
        public string Ip { get; private set; }

        public Szerver(string sor)
        {
            string[] adatok = sor.Split(';');
            this.Domaincim = adatok[0];
            this.Ip = adatok[1];
        }

        /*Készítsen metódust vagy függvényt Domain azonosítóval, amely visszatér a domainnév megadott szintű részével! 
        A szintet (1..5) a függvény paraméterében lehessen megadni. A legfelső szintű domaint (top level domain) az 1-es érték jelölje! 
        Az IP-cím a függvény paramétere vagy metódus esetén az osztály adattagja legyen! 
        Ha nem létezik a megadott szintű név, akkor a „nincs” értékkel térjen vissza az alprogram!
        */
        public string Domain(int szint)
        {
            string[] reszek = this.Domaincim.Split('.');
            if (szint > reszek.Length)
            {
                return "Nincs";
            }
            else
            {
                int index = reszek.Length - szint;
                return reszek[index];
            }
        }
    }
}