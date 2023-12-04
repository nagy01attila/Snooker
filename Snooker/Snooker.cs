using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class Versenyzo
{
    public int Helyezes { get; set; }
    public string Nev { get; set; }
    public string Orszag { get; set; }
    public int Nyeremeny { get; set; }
}

class Snooker
{
    public List<Versenyzo> versenyzok;


    
    public Snooker()
    {
        versenyzok = new List<Versenyzo>();
        try
        {
            // beolvasasás
            string[] lines = File.ReadAllLines("snooker.txt") .Skip(1).ToArray();
            foreach (var line in lines)
            {
                string[] parts = line.Split(';');
                Versenyzo versenyzo = new Versenyzo
                {
                    Helyezes = int.Parse(parts[0]),
                    Nev = parts[1],
                    Orszag = parts[2],
                    Nyeremeny = int.Parse(parts[3])
                };
                versenyzok.Add(versenyzo);
            }
        }
        catch 
        {
            Console.WriteLine($"Hiba hiba van a fájlbrolvasásban!.");
        }
    }

    //3-as
    public void VersenyzokSzama()
    {
        Console.WriteLine($"3. feladat: A világranglistán {versenyzok.Count} versenyző szerepel.");
    }

    //4-es
    public void AtlagosNyeremeny()
    {
        double atlagNyeremeny = versenyzok.Average(v => v.Nyeremeny);
        Console.WriteLine($"4. feladat: A versenyzők Átlagosan {atlagNyeremeny:F2} fontot kerestek az elmúlt időszakban.");
    }

    public void LegtobbetKeresoVersenyzo()
    {
        var legtobbetKereso = versenyzok.OrderByDescending(v => v.Nyeremeny).FirstOrDefault();

        if (legtobbetKereso != null)
        {
            Console.WriteLine($"5. feladat: A legtobbet kereső versenyző: {legtobbetKereso.Nev} ({legtobbetKereso.Orszag}) - {legtobbetKereso.Nyeremeny} ft");
        }
        else
        {
            Console.WriteLine("Nincs adat a legtobbet kereso versenyzorol.");
        }
    }
}

