using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.DataAccessLayer.Context;
using MyPortfolioProject.DataAccessLayer.Entities;

namespace MyPortfolioProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AboutController : Controller
    {
        PortfolioContext portfolioContext = new PortfolioContext();
        public IActionResult AboutList()
        {
            var values = portfolioContext.Abouts.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var values = portfolioContext.Abouts.Find(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateAbout(About about)
        {
            portfolioContext.Abouts.Update(about);
            portfolioContext.SaveChanges();
            return RedirectToAction("AboutList");
        }
    }
}
