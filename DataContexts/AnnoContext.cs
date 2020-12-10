
using FinalProject.Models;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FinalProject.DataContexts
{
    public class AnnoContext : DbContext 
    {
        public AnnoContext() : base("DefaultConnection")
        { }

        public DbSet<Category> categories { get; set; }
        public DbSet<PDF> PDFs { get; set; }
        public DbSet<Annotation> annotations { get; set; }
        public DbSet<Comment> comments { get; set; }

    }
}