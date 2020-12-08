namespace FinalProject.Migrations
{
    using FinalProject.MigrationCommands;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FinalProject.DataContexts.AnnoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(FinalProject.DataContexts.AnnoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //context.PDFs.AddOrUpdate(
            //   t => t.filename, MakePDFs.getPdfs().ToArray());
            //context.SaveChanges();

            //context.annotations.AddOrUpdate(f => new { f.content }, MakePDFs.getAnno(context).ToArray());
            //context.SaveChanges();
        }
    }
}
