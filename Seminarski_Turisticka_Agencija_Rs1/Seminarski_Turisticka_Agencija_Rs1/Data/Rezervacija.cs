using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seminarski_Turisticka_Agencija_Rs1.Data
{
    public class Rezervacija
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int BrojOdraslihOsoba { get; set; }
        public int BrojDjece { get; set; }
        public DateTime OD { get; set; }
        public DateTime DO { get; set; }
        public string Poruka { get; set; }
        public int PonudaId { get; set; }
        public Ponuda Ponuda { get; set; }
        public int KorisnikId { get; set; }
        public Korisnik Korisnik { get; set; }
    }
}
