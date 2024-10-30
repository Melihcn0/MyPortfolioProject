using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.DataAccessLayer.Context;

namespace MyPortfolioProject.ViewComponents
{
    public class _MessageComponentPartial : ViewComponent
    {
        PortfolioContext _context = new PortfolioContext();
        public IViewComponentResult Invoke()
        {
            var values = _context.Messages.ToList();
            return View(values);
        }
    }
}
