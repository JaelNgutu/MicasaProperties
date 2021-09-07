using MicasaProperties.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicasaProperties.Areas.Admin.Controllers
{


    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> userManager;
       

        public UserController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
            
        }
        public IActionResult Index()
        {
            return View(userManager.Users);
        }
    }
}
