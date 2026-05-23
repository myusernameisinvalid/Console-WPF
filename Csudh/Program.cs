using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace csudh
{
    public class Program
    {
        static List<Szerver> szerverek = new List<Szerver>();
        public static void Main(string[] args)
        {
            Console.ReadLine();
            StreamReader sr = new StreamReader("csudh.txt");
            while (!sr.EndOfStream)
            {
                szerverek.Add(new Szerver(sr.ReadLine()));
            }
            sr.Close();

            //Írja ki a képernyőre, a domainek-ip cím párosok adatait, és azt, hogy mennyi cím van a listában!
            foreach (var item in szerverek)
            {
            Console.WriteLine($"Domain: {item.Domaincim} IP: {item.Ip}");
            }
            Console.WriteLine($"A címek száma a listában: {szerverek.Count()}");

            //Írja ki a képernyőre a forrásállományban lévő első domainnév felépítését a minta szerint! Célszerű az előző feladatban kódolt függvényt felhasználni.
            Console.WriteLine("Az első domain felépítése:");
            Szerver elsoszerver = szerverek[1];
            for (int i = 1; i <= 5; i++)
            {
                string szintertek = elsoszerver.Domain(i);
                Console.WriteLine($"{i}. szint: {szintertek}");
            }
            Console.ReadKey();
        }
    }
}
