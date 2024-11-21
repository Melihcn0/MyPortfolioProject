using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.DataAccessLayer.Context;
using MyPortfolioProject.DataAccessLayer.Entities;

namespace MyPortfolioProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MessageController : Controller
    {
        PortfolioContext _context = new PortfolioContext();

        public IActionResult MessageList(int page = 1, int pageSize = 10, bool isRead = false)
        {
            if (page < 1)
            {
                page = 1; // Negatif veya sıfır değerlerini engeller
            }

            var messages = _context.Messages
                .Where(m => m.IsRead == isRead)
                .OrderByDescending(m => m.SendDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var totalMessages = _context.Messages.Where(m => m.IsRead == isRead).Count();
            var totalPages = (int)Math.Ceiling((double)totalMessages / pageSize);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.IsRead = isRead;

            return View(messages);
        }


        public IActionResult ChangeIsReadToTrue(int id, int page, bool isRead)
        {
            var value = _context.Messages.Find(id);
            value.IsRead = true;
            _context.SaveChanges();
            return RedirectToAction("MessageList", new { page = page, isRead = isRead });
        }

        public IActionResult ChangeIsReadToFalse(int id, int page, bool isRead)
        {
            var value = _context.Messages.Find(id);
            value.IsRead = false;
            _context.SaveChanges();
            return RedirectToAction("MessageList", new { page = page, isRead = isRead });
        }

        public IActionResult DeleteMessage(int id, int page, bool isRead)
        {
            var value = _context.Messages.Find(id);
            _context.Messages.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("MessageList", new { page = page, isRead = isRead });
        }

        public IActionResult DetailMessage(int id)
        {
            // Veritabanından MessageID'ye göre mesajı getir
            var value = _context.Messages.FirstOrDefault(m => m.MessageID == id);
            // Mesajın durumuna göre başlığı ayarla
            ViewBag.MessageStatus = value.IsRead ? "Okunmuş Mesajlar" : "Okunmamış Mesajlar";
            // Mesajı View'a gönder
            return View(value);
        }

        public IActionResult CreateMessage()
        {
            return View(new Message());
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(Message message)
        {
            if (ModelState.IsValid)
            {
                message.SendDate = DateTime.Now;
                // Veritabanına kaydetme işlemi
                _context.Messages.Add(message);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Default");
            }
                return View(message);
        }
    }
    }