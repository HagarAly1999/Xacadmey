using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xacadmey.Models;
using Xacadmey.ViewModel;

namespace Xacadmey.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> _UserManager, SignInManager<ApplicationUser>_signInManager)
        {
            userManager = _UserManager;
            signInManager = _signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryTokenAttribute]
        public async Task< IActionResult >Register(RegisterUserModel newuservm)
        {
            //create acount
            if (ModelState.IsValid) {
                ApplicationUser user = new ApplicationUser();   
                user.UserName = newuservm.UserName;
                user.Email = newuservm.Email;
                user.Address = newuservm.Address;

               IdentityResult result=   await userManager.CreateAsync(user,newuservm.Password);
                if(result.Succeeded==true)
                
                 {
                    await signInManager.SignInAsync(user,false);
                    return RedirectToAction("login", "Account");

                }
                else {
                    foreach (var item in result.Errors) { ModelState.AddModelError("", item.Description); }
                
                
                }
            }
            return View(newuservm);
        }
        [HttpGet]
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]  
        [ValidateAntiForgeryTokenAttribute]
        public async Task<IActionResult>login(loginviewmodel uservm )
        {
            if (ModelState.IsValid) { 
            
               ApplicationUser usermodel= await userManager.FindByNameAsync(uservm.UserName);
                if (usermodel != null) {

                     //await signInManager.SignInAsync(usermodel,false);
                   bool found =await userManager.CheckPasswordAsync(usermodel, uservm.Password);
                    if (found)
                    {
                       await signInManager.SignInAsync(usermodel, uservm.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("", "username and password Invalid");
            }
            return View(uservm);
        }
        public async Task<IActionResult> logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("login", "Account");
        }
    }
}
