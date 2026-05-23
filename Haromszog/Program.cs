using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace haromszogekCLI
{
    public class Program
    {
        static List<Haromszog> haromszogek = new List<Haromszog>();
        public static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("haromszogek2.csv");
            while (!sr.EndOfStream)
            {
                haromszogek.Add(new Haromszog(sr.ReadLine()));
            }
            sr.Close();

            /*Jelenítse meg az összes derékszögű háromszög oldalait a következő nézetben:
            Derékszögű háromszögek adatai:
            a: 3 b: 4 c: 5
            a: 6 b: 8 c: 10
            ...
            */
            Console.WriteLine("Derékszögű háromszögek adatai:");
            foreach (var item in haromszogek)
            {
                if (item.derekszogu(item.a,item.b,item.c))
                {
                    Console.WriteLine($"a: {item.a} b:{item.b} c:{item.c}");
                }
            }

            //A program jelenítse meg a legnagyobb területű derékszögű háromszög adatait! (derékszögű háromszög területe: a* b/ 2)
            var legnagyobb = haromszogek.Where(item => item.derekszogu(item.a,item.b,item.c)).OrderByDescending(item => (item.a * item.b) / 2.0).FirstOrDefault();
            if (legnagyobb != null)
            {
                Console.WriteLine("A legnagyobb területű derékszögű háromszög adatai:");
                Console.WriteLine($"a: {legnagyobb.a}b:{legnagyobb.b} c:{legnagyobb.c}");
            }
            Console.ReadKey();
        }
    }
}
