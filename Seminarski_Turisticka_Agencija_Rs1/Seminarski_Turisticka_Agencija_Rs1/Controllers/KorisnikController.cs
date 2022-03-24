using Microsoft.AspNetCore.Mvc;
using Seminarski_Turisticka_Agencija_Rs1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seminarski_Turisticka_Agencija_Rs1.Controllers
{
    public class KorisnikController : Controller
    {
        private readonly AppIdentityDbContext db;
        public KorisnikController(AppIdentityDbContext context) => db = context;
        public IActionResult Index(int Id)
        {
            var administrator = db.Administrator.Find(Id);
            var x = new KorisnikIndexVM
            {
                AdministratorId = Id,
                Administrator = administrator.Ime + " " + administrator.Prezime,
                rows = db.Korisnik.Where(s => s.AdministratorId == Id)
                .Select(s => new KorisnikIndexVM.Row
                {
                    KorisnikId = s.Id,
                    Ime = s.Ime,
                    Prezime = s.Prezime,
                    DatumRodjenja = s.DatumRodjenja.ToString("dd/MM/yyyy"),
                    Telefon = s.Telefon,
                    Email = s.Email,
                    NazivDrzave = s.NazivDrzave,
                    NazivGrada = s.NazivGrada

                }).ToList()
            };
            return View(x);
        }
    }
}
