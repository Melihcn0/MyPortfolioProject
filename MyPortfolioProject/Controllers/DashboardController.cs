using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolioProject.DataAccessLayer.Context;

namespace MyPortfolioProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        PortfolioContext _context = new PortfolioContext();
        public IActionResult Index()
        {
            ViewBag.SkillsCount = _context.Skills.Count();
            ViewBag.MessageCount = _context.Messages.Count();
            ViewBag.NotReadMessageCount = _context.Messages.Where(x => x.IsRead == false).Count();
            ViewBag.ReadMessageCount = _context.Messages.Where(x => x.IsRead == true).Count();
            return View();
        }
    }
}
