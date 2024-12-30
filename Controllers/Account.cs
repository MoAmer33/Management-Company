using day2.Models;
using day2.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Security.Claims;

namespace day2.Controllers
{
    public class Account : Controller
    {
        UserManager<ApplicationUser> _UserManager;
        SignInManager<ApplicationUser> _SignInManager;
        public Account(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _UserManager = userManager;
            _SignInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> SaveRegister(RegisterViewModel register)
        { 
            ApplicationUser user_register=new ApplicationUser();

            if (ModelState.IsValid)
            {
                user_register.Email = register.Email;
                user_register.UserName = register.Name;
                user_register.Address = register.Address;
                user_register.PasswordHash = register.Password;
                IdentityResult result = await _UserManager.CreateAsync(user_register,user_register.PasswordHash);
                if (result.Succeeded)
                {
                   return RedirectToAction("Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }    
            }
            return View("Register", register);

        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View("Login");
        }
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveLogin(LoginUser UserLogin)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await _UserManager.FindByNameAsync(UserLogin.UserName);
                if (user != null)
                {
                    bool check = await _UserManager.CheckPasswordAsync(user, UserLogin.Password);
                    var role = await _UserManager.GetRolesAsync(user);
                    //Sign In with Admin
                    if (check)
                    {
                        if (UserLogin.CheckRole == true)
                        {
                            
                            if (role.Count != 0)
                            {
                                await _SignInManager.SignInAsync(user, UserLogin.rememmberMe);
                                return RedirectToAction("Show", "Department");
                            }
                        }
                        // Sign in with User
                        else
                        {
                            if (role.Count == 0)
                            {
                            List<Claim> claims = new List<Claim>();
                            claims.Add(new Claim("Address", user.Address));
                            await _SignInManager.SignInWithClaimsAsync(user, UserLogin.rememmberMe, claims);
                            return RedirectToAction("Show", "Department");
                            }
                            
                        }
                    }
                }
               
            }
                ModelState.AddModelError("", "Invalid Name or Password");
            return View("Login",UserLogin);
        }
        public async Task<IActionResult> SignOut()
        {
            await _SignInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
