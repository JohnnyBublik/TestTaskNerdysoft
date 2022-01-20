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
            Announcement announcement1 = announcementContext.Announcements.Find(id);
            IEnumerable<Announcement> announcements = announcementContext.Announcements;
            List<Announcement> announcements2 = new List<Announcement>();
            ViewBag.Announcement = announcements;

            string wordname1 = "";
            announcement1.Name += " ";
            announcement1.Description += " ";
            for (int i = 0; i < announcement1.Name.Length; i++)
            {
                if (announcement1.Name[i] != ' ')
                {
                    wordname1 += announcement1.Name[i];
                }
                else // Есть слово из имени доминирующего объекта
                {
                    foreach (var announcementj in announcements) // Проход по вторичным объектам
                    {
                        if (announcementj != announcement1)
                        {
                            if (announcementj.Name.Contains(wordname1))
                            {
                                string worddesc1 = "";
                                foreach (char symbolofdesc1 in announcement1.Description)
                                {
                                    if (symbolofdesc1 != ' ')
                                    {
                                        worddesc1 += symbolofdesc1;
                                    }
                                    else //Есть слово из описания доминирующего объекта
                                    {
                                        if (announcementj.Description.Contains(worddesc1))
                                        {
                                            announcements2.Add(announcementj);
                                            break;
                                        }
                                        worddesc1 = "";
                                    }
                                }
                            }
                            /*if(announcementj!=announcement1)
                            { 
                            string wordname2 = "";
                            foreach (char symbolofname2 in announcementj.Name)
                            {
                                    if (symbolofname2 != ' ')
                                    {
                                        wordname2 += symbolofname2;
                                    }
                                    else //Есть слово из имени вторичного объекта
                                    {

                                        if (wordname1 == wordname2) // Проверка двух слов из имени
                                        {
                                            string worddesc1 = "";
                                            foreach (char symbolofdesc1 in announcement1.Description)
                                            {
                                                if (symbolofdesc1 != ' ')
                                                {
                                                    worddesc1 += symbolofdesc1;
                                                }
                                                else //Есть слово из описания доминирующего объекта
                                                {
                                                    string worddesc2 = "";
                                                    foreach (char symbolofdesc2 in announcementj.Description)
                                                    {
                                                        if (symbolofdesc2 != ' ')
                                                        {
                                                            worddesc2 += symbolofdesc2;
                                                        }
                                                        else
                                                        {
                                                            if (worddesc1 == worddesc2)
                                                            {
                                                                announcements2.Add(announcementj);
                                                                break;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }*/
                        }
                    }
                    wordname1 = "";
                }

                if (announcements2.Count == 3)
                    break;
            }
            announcement1.Name.Trim();
            announcement1.Description.Trim();
            ViewBag.Announcement = announcement1;
            IEnumerable<Announcement> announcementssimilar = announcements2;
            ViewBag.AnnouncementSimilar = announcementssimilar;
            return View();
        }
        [HttpPost]
        public ActionResult Show()
        {
            return RedirectToAction("Index");
        }
    }
}