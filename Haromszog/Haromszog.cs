using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace haromszogekCLI
{
    public class Haromszog
    {
        public int a { get;private set; }
        public int b { get; private set; }
        public int c { get; private set; }

        public Haromszog(string sor)
        {
            string[] adatok = sor.Split(' ');
            this.a = int.Parse(adatok[0]);
            this.b = int.Parse(adatok[1]);
            this.c = int.Parse(adatok[2]);
        }

        /*A program tartalmazzon egy függvényt amely eldönti egy háromszögről, hogy
        derékszögű-e! A függvény megkap egy háromszög példányt, vagy annak oldalait, és
        eldönti róla, hogy derékszögű e!
        Egy háromszög derékszögű ha teljesül rá a Pitagorasz-tétele:. a 2 +b 2 =c 2 ,
        Mivel az adatok növekvő sorrendben vannak így az utolsó érték lehet csak az átfogó.
        Ez alapján könnyen ellenőrizhető, hogy a háromszög derékszögű-e.
        A függvény igaz logikai értékkel tér vissza, amennyiben a háromszög derékszögű! Hamissal, ha nem az!
        */
        public bool derekszogu(int a,int b,int c)
        {
            if ((a * a) + (b * b) == (c * c))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}