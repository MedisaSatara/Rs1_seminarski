using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Seminarski_Turisticka_Agencija_Rs1.Data;
using Seminarski_Turisticka_Agencija_Rs1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seminarski_Turisticka_Agencija_Rs1.Controllers
{
    public class OrganizatorController : Controller
    {
        private AppIdentityDbContext db;
        public OrganizatorController(AppIdentityDbContext context) => db = context;
        public IActionResult Index(/*int Id*/)
        {
            //var administrator = db.Administrator.Find(Id);
            var x = new OrganizatorIndexVM
            {
               // AdministratorId = Id,
                //Adminisrator = administrator.Ime + " " + administrator.Prezime,

                rows = db.Organizator
                .Select(s => new OrganizatorIndexVM.Row
                {
                    OrganizatorId = s.Id,
                    Ime = s.Ime,
                    Prezime = s.Prezime,
                    Telefon = s.Telefon,
                    Email = s.Email,
                    DatumRodjenja = s.DatumRodjenja.ToString("dd/MM/yyyy"),
                    NazivGrada = s.NazivGrada,
                    NazivDrzave = s.NazivDrzave
                }).ToList()
            };
            return View(x);
        }
        public IActionResult Uredi(int Id)
        {
            var organizator = db.Organizator.Find(Id);
            OrganizatorDodajVM x;
            if (Id == 0)
            {
                x = new OrganizatorDodajVM() { };
            }
            else
            {
                x = db.Organizator
                    .Where(s => s.Id == Id)
                    .Select(s => new OrganizatorDodajVM
                    {
                        OrganizatorId = s.Id,
                        Ime = s.Ime,
                        Prezime = s.Prezime,
                        DatumRodjenja = s.DatumRodjenja,
                        Telefon = s.Telefon,
                        Email = s.Email,
                        NazivGrada = s.NazivGrada,
                        NazivDrzave = s.NazivDrzave,
                        AdministratorId = s.AdministratorId
                    }).Single();
            }
            return View("Uredi", x);
        }
        public IActionResult Snimi(OrganizatorDodajVM x)
        {
            Organizator organizator;
            if (x.OrganizatorId == 0)
            {
                organizator = new Organizator();
                db.Add(organizator);
                TempData["PorukaInfo"] = "Uspjesno ste dodali organizatora" + organizator.Ime;

            }
            else
            {
                organizator = db.Organizator.Find(x.OrganizatorId);
                TempData["PorukaInfo"] = "Uspjesno ste editovali organizatora " + organizator.Ime;
            }
            organizator.AdministratorId = x.AdministratorId;
            organizator.Ime = x.Ime;
            organizator.Prezime = x.Prezime;
            organizator.DatumRodjenja = x.DatumRodjenja;
            organizator.Telefon = x.Telefon;
            organizator.NazivGrada = x.NazivGrada;
            organizator.NazivDrzave = x.NazivDrzave;
            organizator.Email = x.Email;
            db.SaveChanges();
            return Redirect("/Organizator/Poruka");


        }
        public IActionResult Poruka()
        {
            return View("Poruka");
        }
        public IActionResult Obrisi(int Id)
        {
            var organizator = db.Organizator.Find(Id);
            db.Remove(organizator);
            db.SaveChanges();
            return Redirect("/Organizator/Index");
        }
        public IActionResult Dodaj(int Id)
        {
            var organizator = db.Organizator
                .Include(s => s.Administrator)
                .Where(s => s.Id == Id)
                .SingleOrDefault();
            var x = new OrganizatorDodajVM
            {
                OrganizatorId = Id,
                AdministratorId = organizator.AdministratorId,
                Administrator = organizator.Administrator.Ime + " " + organizator.Administrator.Prezime
            };
            return View(x);
        }
    }
}
