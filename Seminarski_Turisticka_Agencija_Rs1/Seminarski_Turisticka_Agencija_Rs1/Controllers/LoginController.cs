using Microsoft.AspNetCore.Mvc;
using Seminarski_Turisticka_Agencija_Rs1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seminarski_Turisticka_Agencija_Rs1.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppIdentityDbContext db;
        public LoginController(AppIdentityDbContext context) => db = context;
            
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Verify(LoginIndexVM vm)
        {
            var u = db.Login.Where(s => s.UserName.Equals(vm.UserName));
            var pass = db.Login.Where(s => s.Password.Equals(vm.Password));
            if(u.Count()==1&&pass.Count()==1)
            {
                ViewBag.message = "LoginSuccess";
                return Redirect("/Administrator/Index");
            }
            else
            {
                ViewBag.message = "Login Failed";
                return View("Index");
            }
        }
        
    }
}
