using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektCsharp
{
    public class Ksiazka
    {
        public int ID { get; set; }
        public string Tytul { get; set; }
        public string Autor { get; set; }
        public int RokWydania { get; set; }
        public bool Dostepna { get; set; }

        public Ksiazka(int id, string tytul, string autor, int rokWydania)
        {
            ID = id;
            Tytul = tytul;
            Autor = autor;
            RokWydania = rokWydania;
            Dostepna = true;
        }

        public Ksiazka(){}
    }
}
