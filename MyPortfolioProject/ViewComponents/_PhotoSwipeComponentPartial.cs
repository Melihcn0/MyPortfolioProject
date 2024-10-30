using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioProject.ViewComponents
{
    public class _PhotoSwipeComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
