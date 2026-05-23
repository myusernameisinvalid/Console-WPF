using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trapezCLI
{
    public class Program
    {
        static List<Trapéz> trapézok = new List<Trapéz>();
        public static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("trapezok.csv");
            while (!sr.EndOfStream)
            {
                trapézok.Add(new Trapéz(sr.ReadLine()));
            }
            sr.Close();

            /*Jelenítse meg az összes trapéz adatát a következő formátumban:
            Trapéz adatai:
            a: 13 b: 5 c: 12 d: 12 m: 9
            a: 10 b: 8 c: 11 d: 10 m: 7
            */
            Console.WriteLine("Szerkeszthető:");
            foreach (var item in trapézok)
            {
                if (item.szerkesztheto())
                {
                    Console.WriteLine(item);
                }
            }

            //Számolja meg és jelenítse meg a derékszögű trapézokat!
            Console.WriteLine("Derékszögűek:");
            int derekszogu = 0;
            foreach (var item in trapézok)
            {
                if (item.derekszogu())
                {
                    Console.WriteLine(item);
                    derekszogu++;
                }
            }
            Console.WriteLine($"Összesen {derekszogu} derékszögű trapéz van.");

            //Számolja meg és jelenítse meg a téglalapokat, mint speciális trapézokat!
            Console.WriteLine("Téglalapok:");
            int teglalap = 0;
            foreach (var item in trapézok)
            {
                if (item.teglalap())
                {
                    Console.WriteLine(item);
                    teglalap++;
                }
            }
            Console.WriteLine($"Összesen {teglalap} téglalap van.");
            Console.ReadKey();
        }
    }
}
