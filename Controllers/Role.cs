using day2.Models;
using day2.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Versioning;
using StackExchange.Redis;
using System.ComponentModel.DataAnnotations;

namespace day2.Controllers
{
    public class Role : Controller
    {
       private RoleManager<IdentityRole> role_manager;
       private UserManager<ApplicationUser> user_manager;

        public Role(RoleManager<IdentityRole> role, UserManager<ApplicationUser> user)
        {
            this.role_manager = role;
            this.user_manager = user;
        }

        public IActionResult Index()
        {
            return View();
        }
        public  IActionResult AddRoleToUser(AddRoleToUser Role)
        {

            Role.Roles = role_manager.Roles.Select(r => new SelectListItem
            {
                Value = r.Name,  // or Id, depending on your requirements
                Text = r.Name    // or the display name you want to show
            }).ToList();
            return View("AddRoleToUser",Role);
        }
        [HttpPost]
        public async Task<IActionResult> SaveAddRoleToUser(AddRoleToUser role)
        {
            
            ApplicationUser user= new ApplicationUser();
           
            user = await user_manager.FindByNameAsync(role.Name);
            if ( user!= null)
            {
                IdentityResult result = await user_manager.AddToRoleAsync(user, role.RoleName);
                if (result.Succeeded)
                {
                   return RedirectToAction("Show", "Department");
                }
                else
                {
                 foreach(var item in result.Errors)
                 ModelState.AddModelError("", item.Description);
                }

            }
            else
            {
                ModelState.AddModelError("","User Not Found");
            }
           
            
            role.Roles = role_manager.Roles.Select(r => new SelectListItem
            {
                Value = r.Name,
                Text = r.Name
            }).ToList();
            return View("AddRoleToUser",role);
        }

        //Like Admin or employee
        public IActionResult AddAuthorizedType() 
        {
            return View();
        }

        public async Task<IActionResult> SaveAddAuthorizedType(RoleViewModel RoleName)
        {

            IdentityRole rolee = new IdentityRole();
            rolee.Name = RoleName.Name;
            IdentityResult result = await role_manager.CreateAsync(rolee);
            if (result.Succeeded)
            {
                RedirectToAction("index", "Home");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
             return View("AddAuthorizedType", RoleName);
        }
    }
}
