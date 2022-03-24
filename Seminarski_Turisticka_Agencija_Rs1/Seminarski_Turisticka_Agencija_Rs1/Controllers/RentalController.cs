using Microsoft.AspNetCore.Mvc;
using Seminarski_Turisticka_Agencija_Rs1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seminarski_Turisticka_Agencija_Rs1.Controllers
{
    public class RentalController : Controller
    {
        private readonly AppIdentityDbContext db;
        public RentalController(AppIdentityDbContext context) => db = context;
        public IActionResult Index()
        {
            var x = new RentalIndexVM
            {
                rows = db.RentAcar.Select(s => new RentalIndexVM.Row
                {
                    RentalId = s.Id,
                    Naziv = s.Naziv,
                    Email = s.Email,
                    Telefon = s.Telefon,
                    Adresa = s.Adresa
                }).ToList()
            };
            return View(x);
        }
    }
}
