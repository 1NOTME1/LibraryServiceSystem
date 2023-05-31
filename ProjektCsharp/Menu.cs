using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektCsharp
{
    public class Menu
    {
        private Biblioteka biblioteka;

        public Menu()
        {
            biblioteka = new Biblioteka();
        }

        public void Uruchom()
        {
            bool zakonczono = false;

            while (!zakonczono)
            {
                Console.Clear();
                Console.WriteLine("==================== MENU ====================");
                Console.WriteLine("1. Dodaj książkę");
                Console.WriteLine("2. Edytuj książkę");
                Console.WriteLine("3. Usuń książkę");
                Console.WriteLine("4. Wyświetl książki");
                Console.WriteLine("5. Zapisz książki do pliku");
                Console.WriteLine("6. Wczytaj książki z pliku");
                Console.WriteLine("7. Dodaj czytelnika");
                Console.WriteLine("8. Edytuj czytelnika");
                Console.WriteLine("9. Usuń czytelnika");
                Console.WriteLine("10. Wyświetl czytelników");
                Console.WriteLine("11. Wypożycz książkę");
                Console.WriteLine("12. Zwróć książkę");
                Console.WriteLine("13. Zapisz czytelników do pliku");
                Console.WriteLine("14. Wczytaj czytelników z pliku");
                Console.WriteLine("15. Wyświetl wypożyczenia");
                Console.WriteLine("16. Wyjście");
                Console.WriteLine("==============================================");
                Console.Write("Wybierz opcję: ");

                int opcja;
                if (int.TryParse(Console.ReadLine(), out opcja))
                {
                    switch (opcja)
                    {
                        case 1:
                            DodajKsiazke();
                            break;
                        case 2:
                            EdytujKsiazke();
                            break;
                        case 3:
                            UsunKsiazke();
                            break;
                        case 4:
                            WyswietlKsiazki();
                            break;
                        case 5:
                            ZapiszDoPliku();
                            break;
                        case 6:
                            WczytajZPliku();
                            break;
                        case 7:
                            DodajCzytelnika();
                            break;
                        case 8:
                            EdytujCzytelnika();
                            break;
                        case 9:
                            UsunCzytelnika();
                            break;
                        case 10:
                            WyswietlCzytelnikow();
                            break;
                        case 11:
                            WypozyczKsiazke();
                            break;
                        case 12:
                            ZwrocKsiazke();
                            break;
                        case 13:
                            ZapiszCzytelnikowDoPliku();
                            break;
                        case 14:
                            WczytajCzytelnikowZPliku();
                            break;
                        case 15:
                            WyswietlWypozyczenia();
                            break;
                        case 16:
                            zakonczono = true;
                            break;
                        default:
                            Console.WriteLine("Nieprawidłowy numer. Proszę wybrać numer: [1-15]");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Nieprawidłowy znak. Wybierz ponownie NUMER: [1-15].");
                }

                Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować...");
                Console.ReadKey();
            }
        }

        private void DodajKsiazke()
        {
            Console.WriteLine("=== Dodaj ksiazke ===");

            Console.Write("Podaj tytul: ");
            string tytul = Console.ReadLine();

            Console.Write("Podaj autora: ");
            string autor = Console.ReadLine();

            Console.Write("Podaj rok wydania: ");
            int rokWydania;
            if (int.TryParse(Console.ReadLine(), out rokWydania))
            {
                Ksiazka ksiazka = new Ksiazka(biblioteka.Ksiazki.Count + 1, tytul, autor, rokWydania);

                biblioteka.DodajKsiazke(ksiazka);

                Console.WriteLine($"Ksiazka o ID: {ksiazka.ID} zostala dodana do biblioteki.");
            }
            else
            {
                Console.WriteLine("Nieprawidlowy rok wydania.");
            }
        }
        private void EdytujKsiazke()
        {
            Console.WriteLine("=== Edytuj ksiazke ===");

            Console.Write("Podaj ID ksiazki do edycji: ");
            int id;
            if (int.TryParse(Console.ReadLine(), out id))
            {
                Ksiazka ksiazka = biblioteka.Ksiazki.Find(k => k.ID == id);
                if (ksiazka != null)
                {
                    Console.Write("Podaj nowy tytul: ");
                    string nowyTytul = Console.ReadLine();

                    Console.Write("Podaj nowego autora: ");
                    string nowyAutor = Console.ReadLine();

                    Console.Write("Podaj nowy rok wydania: ");
                    int nowyRokWydania;
                    if (int.TryParse(Console.ReadLine(), out nowyRokWydania))
                    {
                        Ksiazka nowaKsiazka = new Ksiazka
                        {
                            ID = ksiazka.ID,
                            Tytul = nowyTytul,
                            Autor = nowyAutor,
                            RokWydania = nowyRokWydania
                        };

                        biblioteka.EdytujKsiazke(id, nowaKsiazka);

                        Console.WriteLine($"Ksiazka o ID {ksiazka.ID} została zaktualizowana");
                    }
                    else
                    {
                        Console.WriteLine("Nieprawidlowy rok wydania.");
                    }
                }
                else
                {
                    Console.WriteLine($"Książka o ID: {id} nie istnieje.");
                }
            }
            else
            {
                Console.WriteLine("Nieprawidlowe ID ksiazki (Podaj numer).");
            }
        }
        private void UsunKsiazke()
        {
            Console.WriteLine("=== Usun ksiazke ===");

            Console.Write("Podaj ID ksiazki do usuniecia: ");
            int id;
            if (int.TryParse(Console.ReadLine(), out id))
            {
                Ksiazka ksiazka = biblioteka.Ksiazki.Find(k => k.ID == id);
                if (ksiazka != null)
                {
                    biblioteka.UsunKsiazke(id);
                    Console.WriteLine($"Ksiazka o ID: {id} zostala usunieta z biblioteki.");
                }
                else
                {
                    Console.WriteLine($"Ksiazka o ID: {id} nie istnieje.");
                }
            }
            else
            {
                Console.WriteLine("Nieprawidlowe ID ksiazki.");
            }
        }
        private void WyswietlKsiazki()
        {
            Console.WriteLine("=== Lista ksiazek w bibliotece ===");
            biblioteka.WyswietlKsiazki();
        }
        private void ZapiszDoPliku()
        {
            Console.WriteLine("=== Zapisz ksiazki do pliku ===");

            Console.Write("Podaj nazwe pliku (bez rozszerzenia): ");
            string nazwaPliku = Console.ReadLine();

            FileHandler.ZapiszDoPlikuTXT(biblioteka.Ksiazki, nazwaPliku);
            Console.WriteLine($"Ksiazki zostaly zapisane do pliku {nazwaPliku}.txt");
            Console.WriteLine("INFORMACJA: Plik tekstowy domyślnie zapisuje się w lokalizacji ProjektCsharp\\ProjektCsharp\\bin\\Debug\\net6.0");
        }
        private void WczytajZPliku()
        {
            Console.WriteLine("=== Wczytaj ksiazki z pliku ===");

            Console.Write("Podaj nazwe pliku (bez rozszerzenia): ");
            string nazwaPliku = Console.ReadLine();

            List<Ksiazka> ksiazkiTXT = FileHandler.WczytajZPlikuTXT(nazwaPliku);
            if (ksiazkiTXT != null)
            {
                biblioteka.Ksiazki = ksiazkiTXT;
                Console.WriteLine($"Ksiazki zostaly wczytane z pliku {nazwaPliku}.txt");
            }
            else
            {
                Console.WriteLine("Blad wczytywania pliku.");
            }
        }


        private void DodajCzytelnika()
        {
            Console.WriteLine("=== Dodaj czytelnika ===");

            Console.Write("Podaj imie: ");
            string imie = Console.ReadLine();

            Console.Write("Podaj nazwisko: ");
            string nazwisko = Console.ReadLine();

            Console.Write("Podaj date urodzenia (w formacie RRRR-MM-DD): ");
            DateTime dataUrodzenia;
            if (DateTime.TryParse(Console.ReadLine(), out dataUrodzenia))
            {
                Czytelnik czytelnik = new Czytelnik(biblioteka.Czytelnicy.Count + 1, imie, nazwisko, dataUrodzenia);

                biblioteka.DodajCzytelnika(czytelnik);

                Console.WriteLine($"Czytelnik o ID: {czytelnik.ID} zostal dodany do biblioteki.");
            }
            else
            {
                Console.WriteLine("Nieprawidlowa data urodzenia.");
            }
        }
        private void EdytujCzytelnika()
        {
            Console.WriteLine("=== Edytuj czytelnika ===");

            Console.Write("Podaj ID czytelnika do edycji: ");
            int id;
            if (int.TryParse(Console.ReadLine(), out id))
            {
                Czytelnik czytelnik = biblioteka.Czytelnicy.Find(c => c.ID == id);
                if (czytelnik != null)
                {
                    Console.Write("Podaj nowe imie: ");
                    string noweImie = Console.ReadLine();

                    Console.Write("Podaj nowe nazwisko: ");
                    string noweNazwisko = Console.ReadLine();

                    Console.Write("Podaj nowa date urodzenia (w formacie RRRR-MM-DD): ");
                    DateTime nowaDataUrodzenia;
                    if (DateTime.TryParse(Console.ReadLine(), out nowaDataUrodzenia))
                    {
                        Czytelnik nowyCzytelnik = new Czytelnik
                        {
                            ID = czytelnik.ID,
                            Imie = noweImie,
                            Nazwisko = noweNazwisko,
                            DataUrodzenia = nowaDataUrodzenia
                        };

                        biblioteka.EdytujCzytelnika(id, nowyCzytelnik);

                        Console.WriteLine($"Czytelnik o ID {czytelnik.ID} zostal zaktualizowany");
                    }
                    else
                    {
                        Console.WriteLine("Nieprawidlowa data urodzenia.");
                    }
                }
                else
                {
                    Console.WriteLine($"Czytelnik o ID: {id} nie istnieje.");
                }
            }
            else
            {
                Console.WriteLine("Nieprawidlowe ID czytelnika (Podaj numer).");
            }
        }
        private void UsunCzytelnika()
        {
            Console.WriteLine("=== Usun czytelnika ===");

            Console.Write("Podaj ID czytelnika do usuniecia: ");
            int id;
            if (int.TryParse(Console.ReadLine(), out id))
            {
                Czytelnik czytelnik = biblioteka.Czytelnicy.Find(c => c.ID == id);
                if (czytelnik != null)
                {
                    biblioteka.UsunCzytelnika(id);
                    Console.WriteLine($"Czytelnik o ID: {id} zostal usuniety z biblioteki.");
                }
                else
                {
                    Console.WriteLine($"Czytelnik o ID: {id} nie istnieje.");
                }
            }
            else
            {
                Console.WriteLine("Nieprawidlowe ID czytelnika.");
            }
        }
        private void WyswietlCzytelnikow()
        {
            Console.WriteLine("=== Lista czytelnikow w bibliotece ===");
            biblioteka.WyswietlCzytelnikow();
        }


        private void WypozyczKsiazke()
        {
            Console.WriteLine("=== Wypożycz książkę ===");

            Console.Write("Podaj ID czytelnika: ");
            int idCzytelnika;
            if (int.TryParse(Console.ReadLine(), out idCzytelnika))
            {
                Czytelnik czytelnik = biblioteka.Czytelnicy.Find(c => c.ID == idCzytelnika);
                if (czytelnik != null)
                {
                    Console.Write("Podaj ID książki: ");
                    int idKsiazki;
                    if (int.TryParse(Console.ReadLine(), out idKsiazki))
                    {
                        Ksiazka ksiazka = biblioteka.Ksiazki.Find(k => k.ID == idKsiazki);
                        if (ksiazka != null)
                        {
                            DateTime dataWypozyczenia = DateTime.Now;
                            DateTime dataZwrotu = dataWypozyczenia.AddDays(14); 

                            Wypozyczenie wypozyczenie = new Wypozyczenie
                            {
                                ID = biblioteka.Wypozyczenia.Count + 1,
                                IDKsiazki = idKsiazki,
                                IDCzytelnika = idCzytelnika,
                                DataWypozyczenia = dataWypozyczenia,
                                DataZwrotu = dataZwrotu
                            };

                            biblioteka.WypozyczKsiazke(idKsiazki, idCzytelnika);

                            Console.WriteLine($"Książka o ID: {idKsiazki} została wypożyczona przez czytelnika o ID: {idCzytelnika}.");
                        }
                        else
                        {
                            Console.WriteLine($"Książka o ID: {idKsiazki} nie istnieje.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nieprawidłowe ID książki (Podaj numer).");
                    }
                }
                else
                {
                    Console.WriteLine($"Czytelnik o ID: {idCzytelnika} nie istnieje.");
                }
            }
            else
            {
                Console.WriteLine("Nieprawidłowe ID czytelnika (Podaj numer).");
            }
        }
        private void ZwrocKsiazke()
        {
            Console.WriteLine("=== Zwróć książkę ===");

            Console.Write("Podaj ID wypożyczenia: ");
            int idWypozyczenia;
            if (int.TryParse(Console.ReadLine(), out idWypozyczenia))
            {
                Wypozyczenie wypozyczenie = biblioteka.Wypozyczenia.Find(w => w.ID == idWypozyczenia);
                if (wypozyczenie != null)
                {
                    Ksiazka ksiazka = biblioteka.Ksiazki.Find(k => k.ID == wypozyczenie.IDKsiazki);
                    if (ksiazka != null)
                    {
                        Console.WriteLine($"Książka o ID: {wypozyczenie.IDKsiazki} została zwrócona przez czytelnika o ID: {wypozyczenie.IDCzytelnika}.");
                        biblioteka.Wypozyczenia.Remove(wypozyczenie);
                    }
                    else
                    {
                        Console.WriteLine($"Nie można odnaleźć książki o ID: {wypozyczenie.IDKsiazki}.");
                    }
                }
                else
                {
                    Console.WriteLine($"Wypożyczenie o ID: {idWypozyczenia} nie istnieje.");
                }
            }
            else
            {
                Console.WriteLine("Nieprawidłowe ID wypożyczenia (Podaj numer).");
            }
        }


        private void ZapiszCzytelnikowDoPliku()
        {
            Console.WriteLine("=== Zapisz czytelników do pliku ===");

            Console.Write("Podaj nazwę pliku (bez rozszerzenia): ");
            string nazwaPliku = Console.ReadLine();

            string pelnaSciezka = $"{nazwaPliku}.txt";
            biblioteka.ZapiszCzytelnikow(pelnaSciezka);

            Console.WriteLine($"Czytelnicy zostali zapisani do pliku {pelnaSciezka}.");
            Console.WriteLine("INFORMACJA: Plik tekstowy domyślnie zapisuje się w lokalizacji ProjektCsharp\\ProjektCsharp\\bin\\Debug\\net6.0");
        }
        private void WczytajCzytelnikowZPliku()
        {
            Console.WriteLine("=== Wczytaj czytelników z pliku ===");

            Console.Write("Podaj nazwę pliku (bez rozszerzenia): ");
            string nazwaPliku = Console.ReadLine();

                string[] lines = File.ReadAllLines(nazwaPliku + ".txt");
                List<Czytelnik> czytelnicy = new List<Czytelnik>();

                foreach (string line in lines)
                {
                    string[] data = line.Split(',');
                    if (data.Length == 4 && int.TryParse(data[0], out int id) && DateTime.TryParse(data[3], out DateTime dataUrodzenia))
                    {
                        Czytelnik czytelnik = new Czytelnik(id, data[1], data[2], dataUrodzenia);
                        czytelnicy.Add(czytelnik);
                    }
                }

                if (czytelnicy.Count > 0)
                {
                    biblioteka.Czytelnicy = czytelnicy;
                    Console.WriteLine($"Czytelnicy zostali wczytani z pliku {nazwaPliku}.txt");
                }
                else
                {
                    Console.WriteLine("Błąd wczytywania pliku lub brak danych czytelników.");
                }
        }
        private void WyswietlWypozyczenia()
        {
            Console.WriteLine("=== Lista czytelnikow w bibliotece ===");
            biblioteka.WyswietlWypozyczenia();
        }
    }


}
