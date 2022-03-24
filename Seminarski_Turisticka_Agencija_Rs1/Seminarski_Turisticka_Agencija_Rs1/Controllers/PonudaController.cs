using Microsoft.AspNetCore.Mvc;
using Seminarski_Turisticka_Agencija_Rs1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seminarski_Turisticka_Agencija_Rs1.Controllers
{
    public class PonudaController : Controller
    {
        private AppIdentityDbContext db;
        public PonudaController(AppIdentityDbContext context) => db = context;
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Istanbul1()
        {
            return View();
        }
        public IActionResult Istanbul2()
        {
            return View();
        }
        public IActionResult Pariz()
        {
            return View();
        }
        public IActionResult Hurghada()
        {
            return View();
        }
        public IActionResult IndexBus()
        {
            return View();
        }
        public IActionResult Prikaz(int Id)
        {
            var organizator = db.Organizator.Find(Id);
            var x = new PonudaIndexVM
            {
                OrganizatorId = Id,
                Organizator = organizator.Ime + " " + organizator.Prezime,
                rows = db.Ponuda.Select(s => new PonudaIndexVM.Row
                {
                    PonudaId = s.Id,
                    NazivPonude = s.NazivPonude
                }).ToList()
            };
            return View(x);
        }
    }
}
