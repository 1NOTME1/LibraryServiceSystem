using System;

namespace ProjektCsharp
{
    public class Czytelnik
    {
        public int ID { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime DataUrodzenia { get; set; }

        public Czytelnik(int id, string imie, string nazwisko, DateTime dataUrodzenia)
        {
            ID = id;
            Imie = imie;
            Nazwisko = nazwisko;
            DataUrodzenia = dataUrodzenia;
        }

        public Czytelnik(){}
        
    }
}
