using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TestTaskNerdysoft.Models
{
    public class AnnouncementContext:DbContext
    {
        public DbSet<Announcement> Announcements { get; set; }
    }
}