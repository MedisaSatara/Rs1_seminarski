using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seminarski_Turisticka_Agencija_Rs1.Data
{
    public class Ponuda
    {
        public int Id { get; set; }
        public string NazivPonude { get; set; }
        public int OrganizatorId { get; set; }
        public Organizator Organizator { get; set; }
    }
}
