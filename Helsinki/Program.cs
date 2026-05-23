using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helsinki1952
{
    internal class Program
    {
        static List<Olimpia> adatok = new List<Olimpia>();
        static void Main(string[] args)
        {
            //Olvassa be a helsinki.txt állományban lévő adatokat és tárolja el egy olyan
            //adatszerkezetben, amely a további feladatok megoldására alkalmas!A fájlban legfeljebb 200 sor lehet.
            StreamReader sr = new StreamReader("helsinki.txt");
            while (!sr.EndOfStream)
            {
                adatok.Add(new Olimpia(sr.ReadLine()));
            }
            sr.Close();

            //Határozza meg és írja ki a képernyőre a minta szerint, hogy hány pontszerző helyezést értek el a magyar olimpikonok!
            Console.WriteLine("3.feladat:");
            Console.WriteLine($"Pontszerző helyezések száma: {adatok.Count()}");

            //Készítsen statisztikát a megszerzett érmek számáról, majd összesítse az érmek számát a minta szerint!
            Console.WriteLine("4.feladat:");
            int arany = adatok.Count(e => e.Helyezes == 1);
            int ezust = adatok.Count(e => e.Helyezes == 2);
            int bronz = adatok.Count(e => e.Helyezes == 3);
            int osszesen = arany + ezust + bronz;
            Console.WriteLine($"Arany: {arany}");
            Console.WriteLine($"Ezüst: {ezust}");
            Console.WriteLine($"Bronz: {bronz}");
            Console.WriteLine($"Összesen: {osszesen}");

            /*Az olimpián az országokat az elért eredményeik alapján rangsorolják. Az 1−6.
            helyezéseket olimpiai pontokra váltják, és ezt összegzik. Határozza meg és írja ki a minta
            szerint az elért olimpiai pontok összegét az alábbi táblázat segítségével!
            /*Helyezés Olimpiai pont
            1.          7
            2.          5
            3.          4
            4.          3
            5.          2
            6.          1
            */
            Console.WriteLine("5.feladat:");
            int[] pontok = { 0, 7, 5, 4, 3, 2, 1 };
            int olimpiaiPontok = adatok.Sum(e => pontok[e.Helyezes]);
            Console.WriteLine($"Olimpiai pontok száma: {olimpiaiPontok}");

            /*Az úszás és a torna sportágakban világversenyeken mindig jól szerepeltek a magyar
            sportolók.Határozza meg és írja ki a minta szerint, hogy az 1952 - es nyári olimpián melyik
            sportágban szereztek több érmet a sportolók! Ha az érmek száma egyenlő, akkor az
            „Egyenlő volt az érmek száma” felirat jelenjen meg!
            */
            Console.WriteLine("6.feladat:");
            int tornaErmek = adatok.Count(e => e.Sportag == "torna" && e.Helyezes <= 3);
            int uszasErmek = adatok.Count(e => e.Sportag == "uszas" && e.Helyezes <= 3);
            if (tornaErmek > uszasErmek)
            {
                Console.WriteLine("Torna sportágban szereztek több érmet");
            }
            else if (uszasErmek > tornaErmek)
            {
                Console.WriteLine("Úszás sportágban szereztek több érmet");
            }
            else
            {
                Console.WriteLine("Egyenlő volt az érmek száma");
            }

            /*A helsinki.txt állományba hibásan, egybeírva „kajakkenu” került a kajak-kenu
            sportág neve. Készítsen szöveges állományt helsinki2.txt néven, amelybe helyesen,
            kötőjellel kerül a sportág neve! Az új állomány tartalmazzon minden helyezést a
            forrásállományból, a sportágak neve elé kerüljön be a megszerzett olimpiai pont is a minta
            szerint! A sorokban az adatokat szóközzel válassza el egymástól!
            */
            Console.WriteLine("7. feladat: helsinki2.txt készítése");
            List<string> kimenetiSorok = new List<string>();
            int[] pontok2 = { 0, 7, 5, 4, 3, 2, 1 };
            foreach (var e in adatok)
            {
                string aktualisSportag = e.Sportag;
                if (aktualisSportag == "kajakkenu")
                {
                    aktualisSportag = "kajak-kenu";
                }
                int olimpiaiPont = pontok2[e.Helyezes];
                string ujSor = $"{e.Helyezes} {e.SportoloSzama} {olimpiaiPont} {aktualisSportag} {e.Versenyszam}";
                kimenetiSorok.Add(ujSor);
            }
            File.WriteAllLines("helsinki2.txt", kimenetiSorok);
            Console.WriteLine("\tA helsinki2.txt fájl sikeresen létrehozva!");

            /*Határozza meg, hogy melyik pontszerző helyezéshez fűződik a legtöbb sportoló! Írja ki a
            minta szerint a helyezést, a sportágat, a versenyszámot és a sportolók számát!
            Feltételezheti, hogy nem alakult ki holtverseny.
            */
            Console.WriteLine("8.feladat:");
            var maxEredmeny = adatok.OrderByDescending(e => e.SportoloSzama).First();
            Console.WriteLine($"Helyezés: {maxEredmeny.Helyezes}");
            Console.WriteLine($"Sportág: {maxEredmeny.Sportag}");
            Console.WriteLine($"Versenyszám: {maxEredmeny.Versenyszam}");
            Console.WriteLine($"Sportolók száma: {maxEredmeny.SportoloSzama}");
            Console.ReadKey();
        }
    }
}
