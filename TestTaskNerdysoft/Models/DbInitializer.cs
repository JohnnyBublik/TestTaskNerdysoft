using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TestTaskNerdysoft.Models
{
    public class DbInitializer : DropCreateDatabaseAlways<AnnouncementContext>
    {
        protected override void Seed(AnnouncementContext context)
        {
            context.Announcements.Add(new Announcement() { Name="First Case", Description="Firts Case Description", DateTime=DateTime.Now });
            context.Announcements.Add(new Announcement() { Name="Second Case", Description="Second Case Description", DateTime=DateTime.Now });
            context.Announcements.Add(new Announcement() { Name="Third Case", Description="Third Case Description", DateTime=DateTime.Now });
            base.Seed(context);
        }
    }
}