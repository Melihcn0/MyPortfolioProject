using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolioProject.DataAccessLayer.Context;
using MyPortfolioProject.DataAccessLayer.Entities;

namespace MyPortfolioProject.Controllers
{
    public class ToDoListController : Controller
    {
        PortfolioContext _context = new PortfolioContext();
        public IActionResult ToDoListList()
        {
            var values = _context.ToDoLists.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateToDoList()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateToDoList(ToDoList toDoList)
        {
            toDoList.Status = false;
            _context.ToDoLists.Add(toDoList);
            _context.SaveChanges();
            return RedirectToAction("ToDoListList");
        }
        public IActionResult DeleteToDoList(int id)
        {
            var value = _context.ToDoLists.Find(id);
            _context.ToDoLists.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("ToDoListList");
        }
        [HttpGet]
        public IActionResult UpdateToDoList(int id)
        {
            var value = _context.ToDoLists.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateToDoList(ToDoList toDoList)
        {
            _context.ToDoLists.Update(toDoList);
            _context.SaveChanges();
            return RedirectToAction("ToDoListList");
        }
        public IActionResult ChangeToDoListStatusToTrue(int id)
        {
            var value = _context.ToDoLists.Find(id);
            value.Status = true;
            _context.SaveChanges();
            return RedirectToAction("ToDoListList");
        }
        public IActionResult ChangeToDoListStatusToFalse(int id)
        {
            var value = _context.ToDoLists.Find(id);
            value.Status = false;
            _context.SaveChanges();
            return RedirectToAction("ToDoListList");
        }
    }
}
