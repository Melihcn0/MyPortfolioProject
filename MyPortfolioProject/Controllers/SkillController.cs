using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.DataAccessLayer.Context;
using MyPortfolioProject.DataAccessLayer.Entities;

namespace MyPortfolioProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SkillController : Controller
    {
        PortfolioContext _context = new PortfolioContext();
        public IActionResult SkillList()
        {
            var values = _context.Skills.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateSkill()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateSkill(Skill skill)
        {
            _context.Skills.Add(skill);
            _context.SaveChanges();
            return RedirectToAction("SkillList");
        }
        public IActionResult DeleteSkill(int id)
        {
            var values = _context.Skills.Find(id);
            _context.Skills.Remove(values);
            _context.SaveChanges();
            return RedirectToAction("SkillList");
        }
        [HttpGet]
        public IActionResult UpdateSkill(int id)
        {
            var values = _context.Skills.Find(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateSkill(Skill skill)
        {
            _context.Skills.Update(skill);
            _context.SaveChanges();
            return RedirectToAction("SkillList");
        }
    }
}
