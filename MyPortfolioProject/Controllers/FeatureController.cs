using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.DataAccessLayer.Context;
using MyPortfolioProject.DataAccessLayer.Entities;
using Newtonsoft.Json.Linq;

namespace MyPortfolioProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FeatureController : Controller
    {
        PortfolioContext _context = new PortfolioContext();
        public IActionResult FeatureList()
        {
            var values = _context.Features.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult UpdateFeature(int id)
        {
            var values = _context.Features.Find(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateFeature(Feature feature)
        {
            _context.Features.Update(feature);
            _context.SaveChanges();
            return RedirectToAction("FeatureList");
        }
    }
}
