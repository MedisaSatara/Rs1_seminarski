using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seminarski_Turisticka_Agencija_Rs1.Models
{
    public class OrganizatorUrediVM
    {
        public int OrganizatorId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string DatumRodjenja { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string NazivGrada { get; set; }
        public string NazivDrzave { get; set; }
    }
}
