using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seminarski_Turisticka_Agencija_Rs1.Models
{
    public class AdministratorUrediVM
    {
        public int AdministratorId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string NazivGrada { get; set; }
        public string NazivDrzave { get; set; }
        public int ZadatakId { get; set; }
        public string Zadatak { get; set; }
    }
}
