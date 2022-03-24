using Microsoft.AspNetCore.Mvc;
using Seminarski_Turisticka_Agencija_Rs1.Data;
using Seminarski_Turisticka_Agencija_Rs1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seminarski_Turisticka_Agencija_Rs1.Controllers
{
    public class AdministratorController : Controller
    {
        private AppIdentityDbContext db;
        public AdministratorController(AppIdentityDbContext context) => db = context;
        public IActionResult Index()
        {
            var x = new AdministratorIndexVM
            {
                rows = db.Administrator.Select(s => new AdministratorIndexVM.Row
                {
                    AdministratorId = s.Id,
                    Ime = s.Ime,
                    Prezime = s.Prezime,
                    Email = s.Email,
                    Telefon = s.Telefon,
                    DatumRodjenja = s.DatumRodjenja.ToString("dd/MM/yyyy"),
                    NazivGrada = s.NazivGrada,
                    NazivDrzave = s.NazivDrzave

                }).ToList()
            };
            return View(x);
        }
        public IActionResult Uredi(int Id)
        {
            var administrator = db.Administrator.Find(Id);
            AdministratorUrediVM x;
            if (Id == 0)
            {
                x = new AdministratorUrediVM() { };
            }
            else
            {
                x = db.Administrator
                    .Where(s => s.Id == Id)
                    .Select(s => new AdministratorUrediVM
                    {
                        AdministratorId = s.Id,
                        Ime = s.Ime,
                        Prezime = s.Prezime,
                        DatumRodjenja = s.DatumRodjenja,
                        Telefon = s.Telefon,
                        Email = s.Email,
                        NazivGrada = s.NazivGrada,
                        NazivDrzave = s.NazivDrzave
                    }).Single();
            }
            return View("Uredi", x);
        }
        public IActionResult Snimi(AdministratorUrediVM x)
        {
            Administrator administrator;
            if (x.AdministratorId == 0)
            {
                administrator = new Administrator();
                db.Add(administrator);
                TempData["PorukaInfo"] = "Uspjesno ste dodali administratora";

            }
            else
            {
                administrator = db.Administrator.Find(x.AdministratorId);
                TempData["PorukaInfo"] = "Uspjesno ste editovali administratora " + administrator.Ime;
            }
            administrator.Ime = x.Ime;
            administrator.Prezime = x.Prezime;
            administrator.DatumRodjenja = x.DatumRodjenja;
            administrator.Telefon = x.Telefon;
            administrator.NazivGrada = x.NazivGrada;
            administrator.NazivDrzave = x.NazivDrzave;
            administrator.Email = x.Email;
            db.SaveChanges();
            return Redirect("/Administrator/Poruka");


        }
        public IActionResult Poruka()
        {
            return View("Poruka");
        }
    }
}
