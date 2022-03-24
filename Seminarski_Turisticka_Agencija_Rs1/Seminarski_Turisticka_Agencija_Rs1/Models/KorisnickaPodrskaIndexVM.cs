using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seminarski_Turisticka_Agencija_Rs1.Models
{
    public class KorisnickaPodrskaIndexVM
    {
        public class Row
        {
            public int KorisnickaPodrskaId { get; set; }
            public string Adresa { get; set; }
            public string Email { get; set; }
            public string Telefon { get; set; }
            public string RadnoVrijeme { get; set; }
        }
        public List<Row> rows { get; set; }
    }
}
