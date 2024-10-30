using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.DataAccessLayer.Context;

namespace MyPortfolioProject.ViewComponents
{
    public class _AboutComponentPartial : ViewComponent
    {
        PortfolioContext _context = new PortfolioContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.aboutTitle = _context.Abouts.Select(x => x.Title).ToList().FirstOrDefault();
            ViewBag.aboutSubDescription = _context.Abouts.Select(x => x.SubDescription).ToList().FirstOrDefault();
            ViewBag.aboutDetails = _context.Abouts.Select(x => x.Details).ToList().FirstOrDefault();
            return View();
        }
    }
}
