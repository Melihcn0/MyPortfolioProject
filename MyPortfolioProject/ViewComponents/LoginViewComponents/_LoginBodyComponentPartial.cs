using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioProject.ViewComponents.LoginViewComponents
{
    public class _LoginBodyComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
