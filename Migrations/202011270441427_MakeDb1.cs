namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeDb1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Annotations", "filename", "dbo.PDFs");
            DropIndex("dbo.Annotations", new[] { "filename" });
            DropPrimaryKey("dbo.PDFs");
            AddColumn("dbo.Annotations", "pdf_id", c => c.Int());
            AddColumn("dbo.PDFs", "id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Annotations", "filename", c => c.String());
            AlterColumn("dbo.PDFs", "filename", c => c.String());
            AddPrimaryKey("dbo.PDFs", "id");
            CreateIndex("dbo.Annotations", "pdf_id");
            AddForeignKey("dbo.Annotations", "pdf_id", "dbo.PDFs", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Annotations", "pdf_id", "dbo.PDFs");
            DropIndex("dbo.Annotations", new[] { "pdf_id" });
            DropPrimaryKey("dbo.PDFs");
            AlterColumn("dbo.PDFs", "filename", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Annotations", "filename", c => c.String(maxLength: 128));
            DropColumn("dbo.PDFs", "id");
            DropColumn("dbo.Annotations", "pdf_id");
            AddPrimaryKey("dbo.PDFs", "filename");
            CreateIndex("dbo.Annotations", "filename");
            AddForeignKey("dbo.Annotations", "filename", "dbo.PDFs", "filename");
        }
    }
}
