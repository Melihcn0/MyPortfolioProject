using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioProject.ViewComponents._LayoutViewComponentPartial
{
    public class _LayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
