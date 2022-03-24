using Microsoft.AspNetCore.Mvc;
using Seminarski_Turisticka_Agencija_Rs1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seminarski_Turisticka_Agencija_Rs1.Controllers
{
    public class RezervacijaController : Controller
    {
        private readonly AppIdentityDbContext db;
        public RezervacijaController(AppIdentityDbContext context) => db = context;
        public IActionResult Index(int Id)
        {
            var korisnik = db.Korisnik.Find(Id);
            var x = new RezervacijaIndexVM
            {
                KorisnikId = Id,
                Korisnik = korisnik.Ime + " " + korisnik.Prezime,
                rows = db.Rezervacija
                .Where(s => s.KorisnikId == Id)
                .Select(s => new RezervacijaIndexVM.Row
                {
                    Id = s.Id,
                    Ime = s.Ime,
                    Prezime = s.Prezime,
                    OD = s.OD,
                    DO = s.DO,
                    BrojDjece = s.BrojDjece,
                    BrojOdraslihOsoba = s.BrojOdraslihOsoba,
                    Poruka = s.Poruka,
                    PonudaId = s.PonudaId,
                    Ponuda = s.Ponuda.NazivPonude

                }).ToList()
            };
            return View(x);
        }
        public IActionResult Dodaj()
        {
            return View();
        }
    }
}
