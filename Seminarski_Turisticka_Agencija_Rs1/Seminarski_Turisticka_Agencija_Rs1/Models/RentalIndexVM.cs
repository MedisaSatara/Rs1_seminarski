using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seminarski_Turisticka_Agencija_Rs1.Models
{
    public class RentalIndexVM
    {
        public class Row
        {
            public int RentalId { get; set; }
            public string Naziv { get; set; }
            public string Adresa { get; set; }
            public string Telefon { get; set; }
            public string Email { get; set; }

        }
        public List<Row> rows { get; set; }
        public int AdministratorId { get; set; }
        public string Administrator { get; set; }
    }
}
