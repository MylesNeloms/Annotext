
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

        public DbSet<PDF> PDFs { get; set; }
        public DbSet<Annotation> annotations { get; set; }
    }
}