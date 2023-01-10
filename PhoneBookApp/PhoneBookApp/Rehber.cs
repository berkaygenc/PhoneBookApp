using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp
{
    public class Rehber
    {
        private string isim;
        private string soyisim;
        private long telefon;

        public string Isim { get => isim; set => isim = value; }
        public string Soyisim { get => soyisim; set => soyisim = value; }
        public long Telefon { get => telefon; set => telefon = value; }
    }
}
