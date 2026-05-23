using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolCLI_V2
{
    public class Program
    {
        static List<Hos> hosok = new List<Hos>();
        public static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("champions2017_V2.txt");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                hosok.Add(new Hos(sr.ReadLine()));
            }
            sr.Close();

            //Hány hős adatai találhatók az állományban? Az eredményt írassa ki a mintának megfelelően a képernyőre!
            Console.WriteLine($"2.feladat: Az állományban {hosok.Count} hős található");

            //Kérje be egy hős nevét, és írassa ki a minta szerint, a hős nevét, a hp és a kategória értékét!
            //Ha a megadott hős nem szerepel az adatállományban, akkor ismételje addig a bekérést, amíg egy helyes hősnevet ad meg a felhasználó.
            Hos talaltHos = null;
            while (talaltHos == null)
            {
                Console.Write("3.feladat: Kérem adja meg a hős nevét: ");
                string bekeres = Console.ReadLine();
                talaltHos = hosok.FirstOrDefault(h => h.Name.Equals(bekeres));
                if (talaltHos == null)
                {
                    Console.WriteLine("Nincs ilyen nevű hős!");
                }
            }
            Console.WriteLine($"{talaltHos.Name} adatai: HP: {talaltHos.HP} Kategória: {talaltHos.Category}");

            //Határozza meg, hogy 15-ös szinten melyik hős rendelkezik a legmagasabb hp szinttel majd adja meg ennek az értékét!
            Hos legmagasabbHp = hosok.OrderByDescending(h => h.HpErtek(15)).First();
            Console.WriteLine($"5.feladat: 15. szinten a legnagyobb HP-vel rendelkező hős {legmagasabbHp.Name}; HP={legmagasabbHp.HpErtek(15)}");
            Console.ReadKey();
        }
    }
}
