using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolCLI_V2
{
    public class Hos
    {
        public string Name { get;private set; }
        public string Title { get;private set; }
        public string Category { get;private set; }
        public string Blurb { get;private set; }
        public double HP { get;private set; }
        public double HPPerLevel { get;private set; }


        public Hos(string sor)
        {
            string[] adat = sor.Split(';');
            this.Name = adat[0];
            this.Title = adat[1];
            this.Category = adat[2];
            this.Blurb = adat[3];
            this.HP = double.Parse(adat[4].Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
            this.HPPerLevel = double.Parse(adat[5].Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
        }

        //Készítsen egy osztálymetódust HpErtek néven, amely meghatározza az adott hős alap hp értékét egy megadott szinten.
        //A metódus paraméterlistájában szerepeljen a hős szintje (1 és 18-as érték közötti egész szám) a visszatérési értéke pedig legyen
        //az adott szinten lévő hős alap hp értéke az adott szinten (hp + (szint-1)* hpperlevel)! Ha nem a kívánt tartományba esik a szint, akkor -1 legyen a visszatérési érték.
        //A következő feladatokban ezt a függvényt is felhasználhatja.
        public double HpErtek(int szint)
        {
            if(szint < 1 || szint > 18)
            {
                return -1;
            }
            return HP + (szint - 1) * HPPerLevel;
        }
    }
}