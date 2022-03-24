using Microsoft.AspNetCore.Mvc;
using Seminarski_Turisticka_Agencija_Rs1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seminarski_Turisticka_Agencija_Rs1.Controllers
{
    public class TuristickiVodicController : Controller
    {
        private readonly AppIdentityDbContext db;
        public TuristickiVodicController(AppIdentityDbContext context) => db = context;
        public IActionResult Index()
        {
            var x = new TuristickiVodicIndexVM
            {
                rows = db.TuristickiVodic
                .Select(s => new TuristickiVodicIndexVM.Row
                {
                    Id = s.Id,
                    Ime = s.Ime,
                    Prezime = s.Prezime,
                    Telefon = s.Telefon,
                    Email = s.Email,
                    DatumRodjenja = s.DatumRodjenja,
                    NazivGrada = s.NazivGrada,
                    NazivDrzave = s.NazivDrzave,
                    JezikId = s.VodicJezik.Where(j => j.TuristickiVodicId == s.Id).Select(j => j.JezikId).FirstOrDefault(),

                    Jezik = s.VodicJezik.Where(j => j.TuristickiVodicId == s.Id).Select(j => j.Jezik.NazivJezika).FirstOrDefault()
                }).ToList()
            };
            return View(x);
        }
        
    }
}
