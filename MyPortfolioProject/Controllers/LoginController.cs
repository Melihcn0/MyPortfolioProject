using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.DataAccessLayer.Context;
using MyPortfolioProject.DataAccessLayer.Entities;
using System.Security.Claims;

namespace MyPortfolioProject.Controllers
{
    public class LoginController : Controller
    {
        PortfolioContext _context = new PortfolioContext();

        // GET: Login
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public async Task<IActionResult> Index([FromBody] Admin user)
        {
            var adminUserInfo = _context.Admins.FirstOrDefault(x => x.AdminMail == user.AdminMail && x.AdminPassword == user.AdminPassword);

            if (adminUserInfo != null)
            {
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, adminUserInfo.AdminMail),
            new Claim(ClaimTypes.Role, "Admin")
        };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), authProperties);

                return Json(new { success = true });
            }

            return Json(new { success = false, message = "Geçersiz kullanıcı adı veya şifre." });
        }

        // Çıkış yap
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Default");
        }
    }
}
