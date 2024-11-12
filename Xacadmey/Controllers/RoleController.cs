using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xacadmey.ViewModel;

namespace Xacadmey.Controllers
{
   
    public class RoleController : Controller
    {
       
        private readonly RoleManager<IdentityRole> roleManger;
        public RoleController(RoleManager<IdentityRole>roleManger)
        {
            this.roleManger=roleManger;
            
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> New(RoleViewModel newrolevm)
        {
            if (ModelState.IsValid) {
                IdentityRole role=new IdentityRole();
                role.Name = newrolevm.RoleName;
                IdentityResult result=  await roleManger.CreateAsync(role);
                if (result.Succeeded) { 
                
                 return View(new RoleViewModel());
                
                }
                foreach (var item in result.Errors)
                {

                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(newrolevm);
        }
    }
}
