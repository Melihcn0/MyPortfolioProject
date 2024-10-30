using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioProject.ViewComponents._LayoutViewComponentPartial
{
    public class _LayoutSideBarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
