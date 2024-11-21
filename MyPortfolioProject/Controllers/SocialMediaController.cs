using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.DataAccessLayer.Context;
using MyPortfolioProject.DataAccessLayer.Entities;

namespace MyPortfolioProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SocialMediaController : Controller
    {
        PortfolioContext _context = new PortfolioContext();
        public IActionResult SocialMediaList()
        {
            var values = _context.SocialMedias.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateSocialMedia(SocialMedia socialMedia)
        {
            _context.SocialMedias.Add(socialMedia);
            _context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
        public IActionResult DeleteSocialMedia(int id)
        {
            var values = _context.SocialMedias.Find(id);
            _context.SocialMedias.Remove(values);
            _context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
        [HttpGet]
        public IActionResult UpdateSocialMedia(int id)
        {
            var values = _context.SocialMedias.Find(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateSocialMedia(SocialMedia socialMedia)
        {
            _context.SocialMedias.Update(socialMedia);
            _context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
    }
}
