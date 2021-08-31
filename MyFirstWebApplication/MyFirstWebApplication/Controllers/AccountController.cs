using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using environment_crime.Models;

namespace environment_crime.Controllers {
  [Authorize]
  public class AccountController : Controller {
    private UserManager<IdentityUser> userManager;
    private SignInManager<IdentityUser> signInManager;

    public AccountController(UserManager<IdentityUser> userMgr, SignInManager<IdentityUser> signInMgr) {
      userManager = userMgr;
      signInManager = signInMgr;
    }
    [AllowAnonymous]
    public ViewResult Login(string returnUrl) {
      return View(new LoginModel {
        ReturnURL = returnUrl
      });
    }
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken] 
    public async Task<IActionResult> Login (LoginModel loginModel) {
      //call database with usermanager 
      IdentityUser user = await userManager.FindByNameAsync(loginModel.UserName);

      if (ModelState.IsValid) { 

      if (user!= null) { //if user exist -> check password
        await signInManager.SignOutAsync();

        //check if input == password -> return 
        if((await signInManager.PasswordSignInAsync(user, loginModel.Password, false, false)).Succeeded) {
            if  (await userManager.IsInRoleAsync(user, "Coordinator")) {
              return Redirect("/Coordinator/StartCoordinator");
            }
            if (await userManager.IsInRoleAsync(user, "Investigator")) {
              return Redirect("/Investigator/StartInvestigator");
            }
            if (await userManager.IsInRoleAsync(user, "Manager")) {
              return Redirect("/Manager/StartManager");
            }
            
        }
      }
     }
      ModelState.AddModelError("", "Felaktigt användarnamn eller lösenord");
      return View(loginModel);
    }
    public async Task<RedirectResult> Logout(string returnUrl = "/") {
      await signInManager.SignOutAsync();
      //Go to returnpage usually just backwards
      return Redirect(returnUrl);
    }
    [AllowAnonymous]
    public ViewResult AccessDenied() {
      return View();
    }
  }
}
