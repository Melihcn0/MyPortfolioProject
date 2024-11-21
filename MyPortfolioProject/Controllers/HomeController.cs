using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
