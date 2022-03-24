using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seminarski_Turisticka_Agencija_Rs1.Models
{
    public class PonudaIndexVM
    {
        public class Row
        {
            public int PonudaId { get; set; }
            public string NazivPonude { get; set; }
        }
        public List<Row> rows { get; set; }
        public int OrganizatorId { get; set; }
        public string Organizator { get; set; }
    }
}
