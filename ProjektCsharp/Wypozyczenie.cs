using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektCsharp
{
    public class Wypozyczenie
    {
        public int ID { get; set; }
        public int IDKsiazki { get; set; }
        public int IDCzytelnika { get; set; }
        public DateTime DataWypozyczenia { get; set; }
        public DateTime DataZwrotu { get; set; }

    }
}
