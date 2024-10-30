using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.DataAccessLayer.Context;
using MyPortfolioProject.DataAccessLayer.Entities;

namespace MyPortfolioProject.Controllers
{
    public class PortfolioController : Controller
    {
        PortfolioContext _context = new PortfolioContext();
        public IActionResult PortfolioList()
        {
            var values = _context.Portfolios.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult UpdatePortfolio(int id)
        {
            var values = _context.Portfolios.Find(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdatePortfolio(Portfolio portfolio)
        {
            _context.Portfolios.Update(portfolio);
            _context.SaveChanges();
            return RedirectToAction("PortfolioList");
        }
    }
}
