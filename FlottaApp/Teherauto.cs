using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlottaApp
{
    public class Teherauto : Jarmu
    {
        public double Teherbiras { get; set; }
        public Teherauto(string rendszam, int alapar, double teherbiras) : base(rendszam,alapar)
        {
            Teherbiras = teherbiras;
        }
        public override int Adokalkulacio()
        {
            double szam = base.Adokalkulacio() + Teherbiras * 10_000;
            return Convert.ToInt32(szam);
        }
        public override string ToString()
        {
            return base.ToString()+$"| Teherbírás: {Teherbiras} t";
        }

    }
}
