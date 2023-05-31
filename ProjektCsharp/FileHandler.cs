using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Formats.Asn1;
using System.Globalization;

namespace ProjektCsharp
{

    public class FileHandler
    {
        public static void ZapiszDoPlikuTXT(List<Ksiazka> ksiazki, string nazwaPliku)
        {
            string filePath = $"{nazwaPliku}.txt";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Ksiazka ksiazka in ksiazki)
                {
                    string linia = $"{ksiazka.ID},{ksiazka.Tytul},{ksiazka.Autor},{ksiazka.RokWydania}";
                    writer.WriteLine(linia);
                }
            }
        }

        public static List<Ksiazka> WczytajZPlikuTXT(string nazwaPliku)
        {
            string filePath = $"{nazwaPliku}.txt";
            if (File.Exists(filePath))
            {
                List<Ksiazka> ksiazki = new List<Ksiazka>();
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string linia;
                    while ((linia = reader.ReadLine()) != null)
                    {
                        string[] dane = linia.Split(',');
                        if (dane.Length == 4)
                        {
                            int id;
                            if (int.TryParse(dane[0], out id))
                            {
                                string tytul = dane[1];
                                string autor = dane[2];
                                int rokWydania;
                                if (int.TryParse(dane[3], out rokWydania))
                                {
                                    Ksiazka ksiazka = new Ksiazka(id, tytul, autor, rokWydania);
                                    ksiazki.Add(ksiazka);
                                }
                                else
                                {
                                    Console.WriteLine("Nieprawidlowy format roku wydania.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Nieprawidlowy format ID.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nieprawidlowy format linii w pliku.");
                        }
                    }
                }
                return ksiazki;
            }
            else
            {
                Console.WriteLine("Plik nie istnieje.");
                return null;
            }
        }

    }
}
