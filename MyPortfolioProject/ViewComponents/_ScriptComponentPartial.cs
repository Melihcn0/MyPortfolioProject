using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioProject.ViewComponents
{
    public class _ScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
