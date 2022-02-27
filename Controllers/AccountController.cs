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
using Microsoft.AspNetCore.Authorization;

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
        [AllowAnonymous]
       public IActionResult Register(){

           return View();
       }

       [HttpPost]
       [AllowAnonymous]
       public async Task<IActionResult> Register(RegisterViewModel model)
       {

           if(ModelState.IsValid)
           {
               var user = new ApplicationUser 
               {
                   FirstName = model.FirstName,
                   LastName = model.LastName,
                   UserName = model.Email,
                   Email = model.Email
               };

               var result = await _userManager.CreateAsync(user , model.Password);

               if(result.Succeeded)
               {
                 var users = _userManager.Users;
                
                //Add first registered user to Admin role.
                 if(users.Count() == 1)
                    await _userManager.AddToRoleAsync(user: user , role: Roles.Admin);

                 //Add new registered users to User role.
                 else
                     await _userManager.AddToRoleAsync(user: user , role: Roles.User);
                  
                if(_signInManager.IsSignedIn(User) && User.IsInRole(Roles.Admin))
                {
                    return RedirectToAction("Index","Home");
                }

                  await _signInManager.SignInAsync(user, isPersistent: false);
                  return RedirectToAction("Index","Home");
               }

               foreach(var error in result.Errors)
               {
                   ModelState.AddModelError("",error.Description);
               }
           }
           return View(model);
       }

        [HttpGet]
        [AllowAnonymous]
       public IActionResult Login(){

           return View();
       }

       [HttpPost]
       [AllowAnonymous]
       public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
       {
           if(ModelState.IsValid){
              
               var result = await _signInManager.PasswordSignInAsync(model.Email , model.Password, model.RememberMe, lockoutOnFailure: false);

               if(result.Succeeded)
               {
                  if(!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                      return LocalRedirect(returnUrl);
                  
                  else
                    return RedirectToAction("Index","Home");
               }

                   ModelState.AddModelError("","Invalid Login!");
               
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
