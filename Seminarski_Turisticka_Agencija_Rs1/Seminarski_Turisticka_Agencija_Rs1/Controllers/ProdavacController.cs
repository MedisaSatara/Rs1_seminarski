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
    public class ProdavacController : Controller
    {
        private readonly AppIdentityDbContext db;
        public ProdavacController(AppIdentityDbContext context) => db = context;
        public IActionResult Index(int Id)
        {
            var administrator = db.Administrator.Find(Id);
            var x = new ProdavacIndexVM
            {
                AdministratorId = Id,
                Administrator = administrator.Ime + " " + administrator.Prezime,
                rows = db.Prodavac.Where(s => s.AdministratorId == Id)
                .Select(s => new ProdavacIndexVM.Row
                {
                    Id = s.Id,
                    Ime = s.Ime,
                    Prezime = s.Prezime,
                    Telefon = s.Telefon,
                    Email = s.Email,
                    DatumRodjenja = s.DatumRodjenja,
                    NazivGrada = s.NazivGrada,
                    NazivDrzave = s.NazivDrzave
                }).ToList()
            };
            return View(x);
        }
        public IActionResult Uredi(int Id)
        {
            var prodavac = db.Prodavac.Find(Id);
            ProdavacDodajVM x;
            if (Id == 0)
            {
                x = new ProdavacDodajVM() { };
            }
            else
            {
                x = db.Prodavac
                    .Where(s => s.Id == Id)
                    .Select(s => new ProdavacDodajVM
                    {
                        Id = s.Id,
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
        public IActionResult Snimi(ProdavacDodajVM x)
        {
            Prodavac prodavac;
            if (x.Id == 0)
            {
                prodavac = new Prodavac();
                db.Add(prodavac);
                TempData["PorukaInfo"] = "Uspjesno ste dodali prodavaca";

            }
            else
            {
                prodavac = db.Prodavac.Find(x.Id);
                TempData["PorukaInfo"] = "Uspjesno ste editovali prodavaca " + prodavac.Ime;
            }
            prodavac.AdministratorId = x.AdministratorId;
            prodavac.Ime = x.Ime;
            prodavac.Prezime = x.Prezime;
            prodavac.DatumRodjenja = x.DatumRodjenja;
            prodavac.Telefon = x.Telefon;
            prodavac.NazivGrada = x.NazivGrada;
            prodavac.NazivDrzave = x.NazivDrzave;
            prodavac.Email = x.Email;
            db.SaveChanges();
            return Redirect("/Prodavac/Poruka");


        }
        public IActionResult Poruka()
        {
            return View("Poruka");
        }
        public IActionResult Obrisi(int Id)
        {
            var prodavac = db.Prodavac.Find(Id);
            db.Remove(prodavac);
            db.SaveChanges();
            return Redirect("/Prodavac/Index");
        }
        public IActionResult Dodaj(int Id)
        {
            var prodavac = db.Prodavac
                .Include(s => s.Administrator)
                .Where(s => s.Id == Id)
                .SingleOrDefault();
            var x = new ProdavacDodajVM
            {
                Id = Id,
                AdministratorId = prodavac.AdministratorId,
                Administrator = prodavac.Administrator.Ime + " " + prodavac.Administrator.Prezime
            };
            return View(x);
        }

    }
}
