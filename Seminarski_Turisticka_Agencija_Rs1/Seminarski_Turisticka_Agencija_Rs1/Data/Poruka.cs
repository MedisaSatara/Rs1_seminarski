using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seminarski_Turisticka_Agencija_Rs1.Data
{
    public class Poruka
    {
        public int Id { get; set; }
        public string TekstPoruke { get; set; }
        public int KorisnickaPodrskaId { get; set; }
        public KorisnickaPodrska KorisnickaPodrska { get; set; }
    }
}
