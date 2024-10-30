using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioProject.ViewComponents._LayoutViewComponentPartial
{
    public class _LayoutScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
