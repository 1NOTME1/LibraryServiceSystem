using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektCsharp
{
    public class Biblioteka
    {
        public List<Ksiazka> Ksiazki { get; set; }
        public List<Czytelnik> Czytelnicy { get; set; }
        public List<Wypozyczenie> Wypozyczenia { get; set; }

        public Biblioteka()
        {
            Ksiazki = new List<Ksiazka>();
            Czytelnicy = new List<Czytelnik>();
            Wypozyczenia = new List<Wypozyczenie>();
        }
        //================================================================KSIAZKA====================================================================================/

        public void DodajKsiazke(Ksiazka ksiazka)
        {
            Ksiazki.Add(ksiazka);
        }
        public void EdytujKsiazke(int id, Ksiazka nowaKsiazka)
        {
            Ksiazka ksiazka = Ksiazki.Find(k => k.ID == id);
            if (ksiazka != null)
            {
                ksiazka.Tytul = nowaKsiazka.Tytul;
                ksiazka.Autor = nowaKsiazka.Autor;
                ksiazka.RokWydania = nowaKsiazka.RokWydania;
            }
        }
        public void UsunKsiazke(int id)
        {
            Ksiazka ksiazka = Ksiazki.Find(k => k.ID == id);
            if (ksiazka != null)
            {
                Ksiazki.Remove(ksiazka);
            }
        }
        public void WyswietlKsiazki()
        {
            Console.WriteLine("Lista ksiazek w bibliotece:");
            foreach (Ksiazka ksiazka in Ksiazki)
            {
                Console.WriteLine($"ID: {ksiazka.ID}, Tytul: {ksiazka.Tytul}, Autor: {ksiazka.Autor}, Rok wydania: {ksiazka.RokWydania}");
            }
        }
        //==========================================================CZYTELNIK=========================================================================================/
        public void DodajCzytelnika(Czytelnik czytelnik)
        {
            Czytelnicy.Add(czytelnik);
        }
        public void EdytujCzytelnika(int id, Czytelnik nowyCzytelnik)
        {
            Czytelnik czytelnik = Czytelnicy.Find(c => c.ID == id);
            if (czytelnik != null)
            {
                czytelnik.Imie = nowyCzytelnik.Imie;
                czytelnik.Nazwisko = nowyCzytelnik.Nazwisko;
                czytelnik.DataUrodzenia = nowyCzytelnik.DataUrodzenia;
            }
        }
        public void UsunCzytelnika(int id)
        {
            Czytelnik czytelnik = Czytelnicy.Find(c => c.ID == id);
            if (czytelnik != null)
            {
                Czytelnicy.Remove(czytelnik);
            }
        }
        public void WyswietlCzytelnikow()
        {
            Console.WriteLine("Lista czytelnikow w bibliotece:");
            foreach (Czytelnik czytelnik in Czytelnicy)
            {
                Console.WriteLine($"ID: {czytelnik.ID}, Imie: {czytelnik.Imie}, Nazwisko: {czytelnik.Nazwisko}, Data urodzenia: {czytelnik.DataUrodzenia}");
            }
        }
        public void ZapiszCzytelnikow(string nazwaPliku)
        {
            using (StreamWriter writer = new StreamWriter(nazwaPliku))
            {
                foreach (Czytelnik czytelnik in Czytelnicy)
                {
                    writer.WriteLine($"{czytelnik.ID},{czytelnik.Imie},{czytelnik.Nazwisko},{czytelnik.DataUrodzenia}");
                }
            }
        }

        //==========================================================WYPOZYCZENIE / ZWROTY=====================================================================================/

        public void WypozyczKsiazke(int idKsiazki, int idCzytelnika)
        {
            Ksiazka ksiazka = Ksiazki.FirstOrDefault(k => k.ID == idKsiazki);
            Czytelnik czytelnik = Czytelnicy.FirstOrDefault(c => c.ID == idCzytelnika);

            if (ksiazka != null && czytelnik != null && ksiazka.Dostepna)
            {
                Wypozyczenie wypozyczenie = new Wypozyczenie
                {
                    ID = Wypozyczenia.Count + 1,
                    IDKsiazki = ksiazka.ID,
                    IDCzytelnika = czytelnik.ID,
                    DataWypozyczenia = DateTime.Now,
                    DataZwrotu = DateTime.Now.AddDays(14)
                };

                Wypozyczenia.Add(wypozyczenie);
                ksiazka.Dostepna = false;

                Console.WriteLine($"Książka o ID: {wypozyczenie.ID} została wypożyczona.");
            }
            else if (ksiazka != null && !ksiazka.Dostepna)
            {
                Console.WriteLine($"Książka o ID: {ksiazka.ID} jest obecnie niedostępna.");
            }
            else
            {
                Console.WriteLine("Nie znaleziono odpowiedniej książki lub czytelnika.");
            }
        }
        public void ZwrocKsiazke(int idWypozyczenia)
        {
            Wypozyczenie wypozyczenie = Wypozyczenia.Find(w => w.ID == idWypozyczenia);

            if (wypozyczenie != null)
            {
                DateTime dataZwrotu = DateTime.Now;

                TimeSpan roznicaCzasu = dataZwrotu - wypozyczenie.DataZwrotu;
                int opoznienie = Math.Max(0, roznicaCzasu.Days);

                int kara = opoznienie * 2;

                Console.WriteLine("Zwrot książki:");
                Console.WriteLine($"ID wypożyczenia: {wypozyczenie.ID}");
                Console.WriteLine($"ID książki: {wypozyczenie.IDKsiazki}");
                Console.WriteLine($"ID czytelnika: {wypozyczenie.IDCzytelnika}");
                Console.WriteLine($"Data wypożyczenia: {wypozyczenie.DataWypozyczenia}");
                Console.WriteLine($"Data zwrotu: {wypozyczenie.DataZwrotu}");
                Console.WriteLine($"Data faktycznego zwrotu: {dataZwrotu}");
                Console.WriteLine($"Opóźnienie (w dniach): {opoznienie}");
                Console.WriteLine($"Kara za opóźnienie: {kara} zł");

                Wypozyczenia.Remove(wypozyczenie);
            }
            else
            {
                Console.WriteLine($"Wypożyczenie o ID: {wypozyczenie.ID} nie zostało znalezione.");
            }
        }
        public void ZapiszWypozyczeniaDoPliku(string nazwaPliku)
        {
            try
            {
                List<string> lines = new List<string>();

                foreach (Wypozyczenie wypozyczenie in Wypozyczenia)
                {
                    string line = $"{wypozyczenie.ID},{wypozyczenie.IDKsiazki},{wypozyczenie.IDCzytelnika},{wypozyczenie.DataWypozyczenia},{wypozyczenie.DataZwrotu}";
                    lines.Add(line);
                }

                File.WriteAllLines(nazwaPliku + ".txt", lines);

                Console.WriteLine($"Wypożyczenia zostały zapisane do pliku {nazwaPliku}.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd podczas zapisywania wypożyczeń do pliku: {ex.Message}");
            }
        }
        public void WyswietlWypozyczenia()
        {
            Console.WriteLine("Lista wypożyczeń:");
            foreach (Wypozyczenie wypozyczenie in Wypozyczenia)
            {
                Console.WriteLine($"ID: {wypozyczenie.ID}");
                Console.WriteLine($"ID Książki: {wypozyczenie.IDKsiazki}");
                Console.WriteLine($"ID Czytelnika: {wypozyczenie.IDCzytelnika}");
                Console.WriteLine($"Data Wypożyczenia: {wypozyczenie.DataWypozyczenia}");
                Console.WriteLine($"Data Zwrotu: {wypozyczenie.DataZwrotu}");
                Console.WriteLine();
            }
        }

    }

}