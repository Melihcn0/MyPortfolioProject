using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.DataAccessLayer.Context;
using MyPortfolioProject.DataAccessLayer.Entities;

namespace MyPortfolioProject.Controllers
{
    public class ContactController : Controller
    {
        PortfolioContext _context = new PortfolioContext();
        public IActionResult ContactList()
        {
            var values = _context.Contacts.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult UpdateContact(int id)
        {
            var value = _context.Contacts.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateContact(Contact contact)
        {
            _context.Contacts.Update(contact);
            _context.SaveChanges();
            return RedirectToAction("ContactList");
        }
        [HttpPost]
        public async Task<IActionResult> AddMessage(Message message)
        {
            if (ModelState.IsValid)
            {
                message.SendDate = DateTime.Now;
                _context.Messages.Add(message);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Default");
            }
            return View(message);
        }
    }
}
