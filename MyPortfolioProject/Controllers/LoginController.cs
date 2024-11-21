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
        public async Task<IActionResult> Index(Admin user)
        {
            // Veritabanından admin bilgilerini kontrol et
            var adminUserInfo = _context.Admins.FirstOrDefault(x => x.AdminMail == user.AdminMail && x.AdminPassword == user.AdminPassword);

            if (adminUserInfo != null)
            {
                // Kullanıcı bilgilerini Claims olarak ekle
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, adminUserInfo.AdminMail),
                    new Claim(ClaimTypes.Role, "Admin") // Kullanıcı rolü belirtiyoruz
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true // Oturum kalıcı olacak mı?
                };

                // Kimlik doğrulama işlemini gerçekleştir
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), authProperties);

                // Admin paneline yönlendir
                return RedirectToAction("Index", "Dashboard");
            }

            // Kullanıcı bulunamadıysa yeniden login sayfasına yönlendir
            ViewBag.ErrorMessage = "Geçersiz kullanıcı adı veya şifre.";
            return View();
        }

        // Çıkış yap
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Default");
        }
    }
}
