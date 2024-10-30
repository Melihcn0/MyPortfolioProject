using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.DataAccessLayer.Context;

namespace MyPortfolioProject.ViewComponents
{
    public class _StatisticComponentPartial : ViewComponent
    {
        PortfolioContext _context = new PortfolioContext();
        public IViewComponentResult Invoke()
        {
            var values = _context.Statistics.ToList();
            return View(values);
        }
    }
}
