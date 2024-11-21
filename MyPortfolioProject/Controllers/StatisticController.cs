using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.DataAccessLayer.Context;
using MyPortfolioProject.DataAccessLayer.Entities;
using System.Linq;

namespace MyPortfolioProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StatisticController : Controller
    {
        PortfolioContext _context = new PortfolioContext();
        public IActionResult StatisticList()
        {
            var values = _context.Statistics.ToList();
            return View(values);
        }
        public IActionResult DeleteStatistic(int id)
        {
            var values = _context.Statistics.Find(id);
            _context.Statistics.Remove(values);
            _context.SaveChanges();
            return RedirectToAction("StatisticList");
        }
        [HttpGet]
        public IActionResult UpdateStatistic(int id)
        {
            var values = _context.Statistics.Find(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateStatistic(Statistic statistic)
        {
            _context.Statistics.Update(statistic);
            _context.SaveChanges();
            return RedirectToAction("StatisticList");
        }
    }
}
