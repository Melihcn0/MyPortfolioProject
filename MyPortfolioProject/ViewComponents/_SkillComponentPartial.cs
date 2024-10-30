using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.DataAccessLayer.Context;

namespace MyPortfolioProject.ViewComponents
{
    public class _SkillComponentPartial : ViewComponent
    {
        PortfolioContext _context = new PortfolioContext();
        public IViewComponentResult Invoke()
        {
            var values = _context.Skills.ToList();
            return View(values);
        }
    }
}
