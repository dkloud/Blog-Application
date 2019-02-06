using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Infrastructure;
using Web.ViewModels.Account;
using BlogApp.UserModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace Web.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        private readonly ApplicationContext _database;
        public AccountController(ApplicationContext applicationContext)
        {
            _database = applicationContext;
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
                return Content("Log out first!");
            return View();
        }

        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            if (registerModel.Login == registerModel.Password)
            {
                ModelState.AddModelError("", "Login and Password must not match");
            }

            if (ModelState.IsValid)
            {
                User user = new User { Login = registerModel.Login, Password = registerModel.Password };
                Role userRole = await _database.Roles.FirstOrDefaultAsync(role => role.RoleType == "user");
                if (userRole != null)
                    user.Role = userRole;

                _database.Users.Add(user);
                await _database.SaveChangesAsync();

                await Authenticate(user);

                return RedirectToAction("Index", "Blog");

            }
            else
                ModelState.AddModelError("","Invalid username or password");

            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return Content("Log out first!");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _database.Users
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Login == model.Login && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(user);

                    return RedirectToAction("Index", "Blog");
                }
                ModelState.AddModelError("", "Invalid username or password");
            }
            return View(model);
        }

        private async Task Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user?.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.RoleType)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public IActionResult CheckLogin(string login)
        {
            User user = _database.Users.FirstOrDefault(u => u.Login == login);
            if (user != null)
                return Json(false);
            return Json(true);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("Cookies");
            return RedirectToAction("Login", "Account");
        }
    }
}