using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seminarski_Turisticka_Agencija_Rs1.Data
{
    public class Destinacija
    {
        public int Id { get; set; }
        public string NazivGrada { get; set; }
        public string NazivDrzave { get; set; }
        public int PonudaId { get; set; }
        public Ponuda Ponuda { get; set; }
    }
}
