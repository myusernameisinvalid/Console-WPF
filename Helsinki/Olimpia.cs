using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helsinki1952
{
    internal class Olimpia
    {
        public int Helyezes { get; set; }
        public int SportoloSzama { get; set; }
        public string Sportag { get; set; }
        public string Versenyszam { get; set; }

        public Olimpia(string sor)
        {
            string[] adatok = sor.Split(' ');
            this.Helyezes = int.Parse(adatok[0]);
            this.SportoloSzama = int.Parse(adatok[1]);
            this.Sportag = adatok[2];
            this.Versenyszam = adatok[3];
        }
    }
}
