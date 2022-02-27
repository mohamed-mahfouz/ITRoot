using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ITRoot.Models;
using ITRoot.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace ITRoot.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        [HttpGet]
       public IActionResult Register(){

           return View();
       }

       [HttpPost]
       public async Task<IActionResult> Register(RegisterViewModel model)
       {
           if(ModelState.IsValid){
               var user = new ApplicationUser {
                   FirstName = model.FirstName,
                   LastName = model.LastName,
                   UserName = model.Email,
                   Email = model.Email
               };

               var result = await _userManager.CreateAsync(user , model.Password);

               if(result.Succeeded){
                  await _signInManager.SignInAsync(user, isPersistent: false);
                  return RedirectToAction("Index","Home");
               }

               foreach(var error in result.Errors){
                   ModelState.AddModelError("",error.Description);
               }
           }
           return View(model);
       }

        [HttpPost]
       public async Task<IActionResult> Logout()
       {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
       }
    }
}
