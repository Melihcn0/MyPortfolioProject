using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.DataAccessLayer.Context;

namespace MyPortfolioProject.ViewComponents
{
    public class _ExperienceComponentPartial : ViewComponent
    {
        PortfolioContext _context = new PortfolioContext();
        public IViewComponentResult Invoke()
        {
            var values = _context.Experiences.ToList();
            return View(values);
        }
    }
}
