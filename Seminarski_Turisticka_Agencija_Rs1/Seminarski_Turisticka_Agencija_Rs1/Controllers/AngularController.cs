using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Seminarski_Turisticka_Agencija_Rs1.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seminarski_Turisticka_Agencija_Rs1.Controllers
{
    public class AngularController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
