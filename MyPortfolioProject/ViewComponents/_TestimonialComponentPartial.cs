using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.DataAccessLayer.Context;

namespace MyPortfolioProject.ViewComponents
{
    public class _TestimonialComponentPartial : ViewComponent
    {
        PortfolioContext _context = new PortfolioContext();
        public IViewComponentResult Invoke()
        {
            var values = _context.Testimonials.ToList();
            return View(values);
        }
    }
}
