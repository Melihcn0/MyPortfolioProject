using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioProject.ViewComponents.LoginViewComponents
{
    public class _LoginScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
