using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TX.Admin.Services;
using TX.ViewModels.Login;

namespace TX.Admin.Controllers
{
    public class UserController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
       
    }
}
