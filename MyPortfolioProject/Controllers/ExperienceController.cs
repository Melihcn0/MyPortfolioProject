using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.DataAccessLayer.Context;
using MyPortfolioProject.DataAccessLayer.Entities;

namespace MyPortfolioProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ExperienceController : Controller
    {
        PortfolioContext _context = new PortfolioContext();
        public IActionResult ExperienceList()
        {
            var values = _context.Experiences.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateExperience()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateExperience(Experience experience)
        {
            _context.Experiences.Add(experience);
            _context.SaveChanges();
            return RedirectToAction("ExperienceList");
        }
        public IActionResult DeleteExperience(int id)
        {
            var values = _context.Experiences.Find(id);
            _context.Experiences.Remove(values);
            _context.SaveChanges();
            return RedirectToAction("ExperienceList");
        }
        [HttpGet]
        public IActionResult UpdateExperience(int id)
        {
            var values = _context.Experiences.Find(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateExperience(Experience experience)
        {
            _context.Experiences.Update(experience);
            _context.SaveChanges();
            return RedirectToAction("ExperienceList");
        }
    }
}
