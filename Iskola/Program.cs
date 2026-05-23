using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iskola
{
    public class Program
    {
        static List<Tanulo> tanulok = new List<Tanulo>();
        public static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("nevek.txt");
            while (!sr.EndOfStream)
            {
                tanulok.Add(new Tanulo(sr.ReadLine()));
            }
            sr.Close();

            //Írja ki a képernyőre, a tanulók adatait, illetve, hogy hány tanuló jár az iskolába!
            Console.WriteLine("3.feladat:");
            foreach (var item in tanulok)
            {
                Console.WriteLine(item.KezdesEve + " " + item.Osztaly + " " + item.Nev);
            }
            Console.WriteLine($"{tanulok.Count()} tanuló jár az iskolába.");

            //Az elkészített jellemzőt/függvényt felhasználva írja ki az adatszerkezetben tárolt
            //első és utolsó tanuló azonosítóját a minta szerint!
            Console.WriteLine("4.feladat:");
            Console.WriteLine($"Első tanuló:{tanulok[0].Nev} - {tanulok[0].Azonosito()}");
            int utolsoindex = tanulok.Count() - 1;
            Console.WriteLine($"Utolsó tanuló: {tanulok[utolsoindex].Nev} - {tanulok[utolsoindex].Azonosito()}");

            //Írja ki az azonosítók txt-be az összes tanuló nevét és azonosítóját!
            Console.WriteLine("5.feladat:");
            StreamWriter sw = new StreamWriter("azonositok.txt");
            foreach (var item in tanulok)
            {
                sw.WriteLine($"{item.Nev} - {item.Azonosito()}");
            }
            sw.Close();
            Console.ReadKey();
        }
    }
}
