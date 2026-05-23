using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogManager
{
    internal class Logok
    {
        public DateTime Idopont { get; set; }
        public string Szint { get; set; }
        public string Uzenet { get; set; }

        public Logok(string sor)
        {
            string[] s = sor.Split(new string[] { " - " }, StringSplitOptions.None);
            this.Idopont = Convert.ToDateTime(s[0]);
            this.Szint = s[1];
            this.Uzenet = s[2];
        }

        public override string ToString()
        {
            return $"{Idopont:yyyy-MM-dd HH:mm:ss} - {Szint} - {Uzenet}";
        }
    }
}