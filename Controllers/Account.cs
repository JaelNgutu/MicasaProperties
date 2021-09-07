using MicasaProperties.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicasaProperties.Controllers
{

  
   
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> userManager , SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;

        }


        public IActionResult Register()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            AppUser appUser = new AppUser
            {
                UserName = "UserThree",
                Email = user.Email
            };

            IdentityResult result = await userManager.CreateAsync(appUser, user.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }

            else
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }


            return View(user);
        }



        public IActionResult Login(string returnUrl)
        {
            Login login = new Login
            {
                ReturnUrl = returnUrl
            };


            return View(login);
        }


        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {

            AppUser appUser = await userManager.FindByEmailAsync(login.Email);
            if(appUser!= null)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync
                    (appUser, login.Password, false, false);

                if (result.Succeeded)
                    return Redirect(login.ReturnUrl ?? "/");


            }

            ModelState.AddModelError("", "wrong info provided");

            return View(login);
        }





        public async Task<IActionResult> Logout()
        {

            await signInManager.SignOutAsync();

            return Redirect("/");
        }


    }
}
