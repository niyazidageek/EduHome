using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduHome.Areas.Admin.Helpers;
using EduHome.Areas.Admin.ViewModels;
using EduHome.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(RegisterAdminVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);
            AppUser user = new AppUser
            {
                Fullname = registerVM.Fullname,
                UserName = registerVM.Username,
                Email = registerVM.Email,
                IsEnabled = true
            };

            IdentityResult result = await _userManager.CreateAsync(user, registerVM.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(registerVM);
            }

            await _userManager.AddToRoleAsync(user, Roles.Admin.ToString());

            return RedirectToAction("Index", "Home");
        }

        //public IActionResult Login()
        //{
        //    if (!User.Identity.IsAuthenticated) return NotFound();
        //    return View();
        //}

        //[HttpPost]
        //[AutoValidateAntiforgeryToken]
        //public async Task<IActionResult> Login(LoginAdminVM loginVM)
        //{
        //    if (!User.Identity.IsAuthenticated) return NotFound();
        //    if (!ModelState.IsValid) return View(loginVM);

        //    AppUser user = await _userManager.FindByNameAsync(loginVM.Username);

        //    if (user == null)
        //    {
        //        ModelState.AddModelError("", "Username or password is not correct");
        //        return View(loginVM);
        //    }

        //    if (!user.IsEnabled)
        //    {
        //        ModelState.AddModelError("", "Your account is blocked");
        //        return View(loginVM);
        //    }

        //    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, loginVM.RememberMe, false);

        //    if (!result.Succeeded)
        //    {
        //        ModelState.AddModelError("", "Username or password is not correct");
        //        return View(loginVM);
        //    }
        //    return RedirectToAction("Index", "Home");
        //}

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
