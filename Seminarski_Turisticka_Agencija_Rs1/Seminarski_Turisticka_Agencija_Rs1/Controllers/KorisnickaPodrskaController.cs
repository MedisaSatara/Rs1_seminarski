using Microsoft.AspNetCore.Mvc;
using Seminarski_Turisticka_Agencija_Rs1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Seminarski_Turisticka_Agencija_Rs1.Controllers
{
    public class KorisnickaPodrskaController : Controller
    {
        private AppIdentityDbContext db;
        public KorisnickaPodrskaController(AppIdentityDbContext context) => db = context;
        public IActionResult Index()
        {
            var x = new KorisnickaPodrskaIndexVM
            {
                rows = db.KorisnickaPodrska.Select(s => new KorisnickaPodrskaIndexVM.Row
                {
                    KorisnickaPodrskaId = s.Id,
                    Email = s.Email,
                    Telefon = s.Telefon,
                    Adresa = s.Adresa,
                    RadnoVrijeme = s.RadnoVrijeme
                }).ToList()
            };
            return View(x);
        }
        
    }
}
