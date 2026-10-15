using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlottaApp;

List<Jarmu> jarmuk = new List<Jarmu>();
int hibasSorokSzama = 0;
int seg = 0;
foreach (var sor in File.ReadAllLines(@"C:\Users\13d\source\repos\FlottaApp\FlottaApp\bin\Debug\jarmuvek.csv").Skip(1))
{
    string[] adatok = sor.Split(';');
    string tipus = adatok[0];
    string rendszam = adatok[1];

    if (adatok.Count() == 4)
    {
        if (!(string.IsNullOrWhiteSpace(tipus) || string.IsNullOrWhiteSpace(rendszam)))
        {
            if (tipus == "J" || tipus == "T")
            {

                if (int.TryParse(adatok[2], out int alapar) && double.TryParse(adatok[3], out double extra))
                {

                    if (tipus == "J")
                    {
                        Jarmu jarmu = new Jarmu(rendszam, alapar);
                        jarmuk.Add(jarmu);
                    }
                    else if (tipus == "T")
                    {
                        Teherauto teherauto = new Teherauto(rendszam, alapar, extra);
                        jarmuk.Add(teherauto);
                    }

                }
                else
                {
                    hibasSorokSzama++;
                    continue;
                }
            }
            else
            {
                hibasSorokSzama++;
                continue;
            }
        }
        else
        {
            hibasSorokSzama++;
            continue;
        }

    }
    else
    {
        hibasSorokSzama++;
        continue;
    }

}
Console.WriteLine("--- FLOTTA ELEMZÉS ---");
Console.WriteLine("Sikeresen beolvasott járművek: {0} db", jarmuk.Count());
Console.WriteLine("Kiszűrt hibás sorok száma: {0} db", hibasSorokSzama);
Console.WriteLine();
Console.WriteLine("--- JÁRMŰVEK LISTÁJA ---");
int osszAdo = 0;
foreach (var item in jarmuk)
{
    Console.WriteLine(item);
    osszAdo += item.Adokalkulacio();
}
Console.WriteLine();
Console.WriteLine("A flotta teljes adóterhe: {0} Ft", osszAdo);
Console.WriteLine("Jármű példányok száma (static): {0} db", Jarmu.OsszesJarmuSzama);



