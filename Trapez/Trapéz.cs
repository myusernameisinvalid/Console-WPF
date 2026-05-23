using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trapezCLI
{
    public class Trapéz
    {
        public int A { get; private set; }
        public int B { get; private set; }
        public int C { get; private set; }
        public int D { get; private set; }
        public int M { get; private set; }

        public Trapéz(string sor)
        {
            string[] s = sor.Split(' ');
            this.A = int.Parse(s[0]);
            this.C = int.Parse(s[1]);
            this.B = int.Parse(s[2]);
            this.D = int.Parse(s[3]);
            this.M = int.Parse(s[4]);
        }

        /*Szerkeszthetőség ellenőrzése:
        A függvény vizsgálja meg, hogy a megadott oldalakkal szerkeszthető-e trapéz.
        Logikai értékkel térjen vissza: igaz, ha szerkeszthető, hamis, ha nem az.
        A trapéz szerkeszthető akkor, ha a következő feltétel teljesül:
        |a - c| &lt; b + d és |b - d| &lt; a + c
        */
        public bool szerkesztheto()
        {
            if (Math.Abs(A - C) < B + D && Math.Abs(B - D) < A + C)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*Derékszögű trapéz felismerése:
        Ellenőrizze, hogy van-e benne derékszög.
        Logikai értékkel térjen vissza.
        Derékszögű ha: Valamelyik szár megegyezik a magassággal. b, d, (szárak) m (magasság)
        */
        public bool derekszogu()
        {
            if (B == M || D == M)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*Téglalap felismerése:
        Ellenőrizze, hogy téglalap-e.
        Logikai értékkel térjen vissza.
        Téglalap, ha derékszögű és b és d szárak megegyeznek!
        */
        public bool teglalap()
        {
            if (derekszogu() && B == D)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"a: {A} b: {C} c:{B} d:{D} m:{M}";
        }
    }
}