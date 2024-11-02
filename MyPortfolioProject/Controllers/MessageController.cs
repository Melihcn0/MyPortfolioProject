﻿using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.DataAccessLayer.Context;
using MyPortfolioProject.DataAccessLayer.Entities;

namespace MyPortfolioProject.Controllers
{
    public class MessageController : Controller
    {
        PortfolioContext _context = new PortfolioContext();

        public IActionResult MessageList()
        {
            var values = _context.Messages.ToList();
            return View(values);
        }

        public IActionResult ChangeIsReadToTrue(int id)
        {
            var value = _context.Messages.Find(id);
            value.IsRead = true;
            _context.SaveChanges();
            return RedirectToAction("MessageList");
        }

        public IActionResult ChangeIsReadToFalse(int id)
        {
            var value = _context.Messages.Find(id);
            value.IsRead = false;
            _context.SaveChanges();
            return RedirectToAction("MessageList");
        }

        public IActionResult DeleteMessage(int id)
        {
            var value = _context.Messages.Find(id);
            _context.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("MessageList");
        }

        public IActionResult DetailMessage(int id)
        {
            var value = _context.Messages.Find(id);
            return View(value);
        }
        [HttpGet]
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
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(message); 
        }
    }
    }