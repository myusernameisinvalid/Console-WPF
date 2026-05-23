using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogManager
{
    internal class Program
    {
        static List<Logok> logok = new List<Logok>();
        static List<Logok> Szures(List<Logok> logok, List<string> feltetelek)
        {
            return logok.Where(l => feltetelek.Contains(l.Szint)).ToList();
        }
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("server.log");
            while (!sr.EndOfStream)
            {
                logok.Add(new Logok(sr.ReadLine()));
            }
            sr.Close();

            //Írja ki a képernyőre a logfájlban található összes bejegyzést és az események számát!
            Console.WriteLine("3. Feladat: Összes bejegyzés:");
            foreach (var item in logok)
            {
                if (true)
                {
                    Console.WriteLine(item);
                }
            }
            Console.WriteLine($"Események száma: {logok.Count}");

            //Számolja meg az egyes eseményszintek (INFO, SUCCESS, WARNING, ERROR) előfordulásainak számát!
            Console.WriteLine("4. Feladat: Eseményszintek előfordulása:");
            int infoDb = logok.Count(l => l.Szint == "INFO");
            int successDb = logok.Count(l => l.Szint == "SUCCESS");
            int warningDb = logok.Count(l => l.Szint == "WARNING");
            int errorDb = logok.Count(l => l.Szint == "ERROR");

            Console.WriteLine($"\tINFO : {infoDb}");
            Console.WriteLine($"\tSUCCESS : {successDb}");
            Console.WriteLine($"\tWARNING : {warningDb}");
            Console.WriteLine($"\tERROR : {errorDb}");

            /*Készítsen metódust, amely szűri a bejegyzéseket egy vagy több eseményszint szerint!
            Például, ha a keresett eseményszint ERROR és WARNING, a képernyőn jelenjenek meg csak
            azok az események a pontos időponttal és üzenettel.A metódus paraméterként kapja a
            bejegyzések listáját valamint a szűrőfeltételek listáját, majd visszaadja a szűrésnek megfelelő listát
            */
            Console.WriteLine("5. Feladat:");
            Console.WriteLine($"\tSzűrt események (ERROR és WARNING):");
            List<string> szurok = new List<string> { "ERROR", "WARNING" };
            List<Logok> szurtLista = Szures(logok, szurok);
            foreach (var log in szurtLista)
            {
                Console.WriteLine($"\t{log}");
            }

            //Határozza meg a legutóbbi ERROR bejegyezés előtti utolsó SUCCESS bejegyzést. Ha nincs ilyen a nincs szó jelenjen meg.
            Console.WriteLine("6. Feladat:Legutóbbi ERROR előtti utolsó SUCCESS:");
            int utolsoErrorIndex = logok.FindLastIndex(l => l.Szint == "ERROR");
            if (utolsoErrorIndex == -1)
            {
                Console.WriteLine("\tnincs");
            }
            else
            {
                var keresettSuccess = logok.Take(utolsoErrorIndex).LastOrDefault(l => l.Szint == "SUCCESS");
                if (keresettSuccess == null)
                {
                    Console.WriteLine("\tnincs");
                }
                else
                {
                    Console.WriteLine($"\t{keresettSuccess}");
                }
            }

            //Mentse el külön fájlba (errors.txt) csak az ERROR eseményszintű bejegyzéseket!
            Console.WriteLine("7. Feladat: ERROR bejegyzések mentése...");
            var errorLogok = logok.Where(l => l.Szint == "ERROR");
            var kimenetiSorok = errorLogok.Select(l => l.ToString());
            File.WriteAllLines("errors.txt", kimenetiSorok);
            Console.WriteLine("\tMentés sikeres az 'errors.txt' fájlba!");
            Console.ReadKey();
        }
    }
}
