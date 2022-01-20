using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTaskNerdysoft.Models;
using System.Data.Entity;

namespace TestTaskNerdysoft.Controllers
{
    public class HomeController : Controller
    {
        AnnouncementContext announcementContext = new AnnouncementContext();
        public ActionResult Index()
        {
            IEnumerable<Announcement> announcements = announcementContext.Announcements;
            ViewBag.Announcement = announcements;

            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return PartialView("Create");
        }
        [HttpPost]
        public ActionResult Create(Announcement announcement)
        {
            announcement.DateTime = DateTime.Now;
            announcementContext.Announcements.Add(announcement);
            announcementContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Announcement announcement)
        {
            announcement.DateTime = DateTime.Now;
            announcementContext.Entry(announcement).State = EntityState.Modified;
            announcementContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Announcement announcement = announcementContext.Announcements.Find(id);
            if (announcement != null)
            {
                announcementContext.Announcements.Remove(announcement);
                announcementContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Show(int id)
        {
            ViewBag.Announcement = announcementContext.Announcements.Find(id);
            return View();
        }
        [HttpPost]
        public ActionResult Show()
        {
            return RedirectToAction("Index");
        }
    }
}