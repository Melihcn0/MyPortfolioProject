using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolioProject.DataAccessLayer.Context;
using MyPortfolioProject.DataAccessLayer.Entities;

namespace MyPortfolioProject.Controllers
{
    public class ToDoListController : Controller
    {
        PortfolioContext _context = new PortfolioContext();
        public IActionResult ToDoListList(int page = 1, int pageSize = 10, bool isRead = false)
        {
            var tasks = _context.ToDoLists
                .Where(t => t.Status == isRead)
                .OrderByDescending(t => t.Date)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var totalTasks = _context.ToDoLists.Where(t => t.Status == isRead).Count();
            var totalPages = (int)Math.Ceiling((double)totalTasks / pageSize);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.IsRead = isRead;

            return View(tasks);
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

        public IActionResult DeleteToDoList(int id, int page, bool isRead)
        {
            var value = _context.ToDoLists.Find(id);
            _context.ToDoLists.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("ToDoListList", new { page = page, isRead = isRead });
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

        public IActionResult ChangeToDoListStatusToTrue(int id, int page, bool isRead)
        {
            var value = _context.ToDoLists.Find(id);
            value.Status = true;
            _context.SaveChanges();
            return RedirectToAction("ToDoListList", new { page = page, isRead = isRead });
        }

        public IActionResult ChangeToDoListStatusToFalse(int id, int page, bool isRead)
        {
            var value = _context.ToDoLists.Find(id);
            value.Status = false;
            _context.SaveChanges();
            return RedirectToAction("ToDoListList", new { page = page, isRead = isRead });
        }
    }
    }
