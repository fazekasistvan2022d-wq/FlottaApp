using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlottaApp
{
    public class Jarmu
    {
        public string Rendszam { get; set; }
        protected int alapar;
        public int Alapar
        {
            get { return alapar; }
            set
            {
                if (value <= 0)
                {
                    alapar = 1_000_000;
                }
                else
                {
                    alapar = value;
                }
            }
        }
        private static int osszesJarmuSzama = 0;
        public static int OsszesJarmuSzama { get { return osszesJarmuSzama; } }

        public Jarmu(string rendszam, int alapar)
        {
            osszesJarmuSzama++;
            Rendszam = rendszam;
            Alapar = alapar;
        }

        public virtual int Adokalkulacio()
        {
            double szam = Math.Round(alapar * 0.05);
            return Convert.ToInt32(szam);
        }

        public override string ToString()
        {
            return $"Jármű: {Rendszam} | Alapár: {alapar} Ft | Adó: {Adokalkulacio()} Ft";
        }

    }
}
