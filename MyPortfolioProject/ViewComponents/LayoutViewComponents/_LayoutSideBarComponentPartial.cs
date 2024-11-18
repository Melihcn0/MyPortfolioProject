using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolioProject.DataAccessLayer.Context;

namespace MyPortfolioProject.ViewComponents._LayoutViewComponentPartial
{
    public class _LayoutSideBarComponentPartial : ViewComponent
    {
        PortfolioContext _context = new PortfolioContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.UnreadMessagesCount = _context.Messages.Where(x => x.IsRead == false).Count();
            ViewBag.IncompleteTasksCount = _context.ToDoLists.Where(x => x.Status == false).Count();
            return View();
        }
    }
}
