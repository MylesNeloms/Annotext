namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Annotations",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        content = c.String(),
                        author = c.String(),
                        VoteVal = c.Int(nullable: false),
                        pageNum = c.Int(nullable: false),
                        paragraph = c.Int(nullable: false),
                        filename = c.String(),
                        pdf_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.PDFs", t => t.pdf_id)
                .Index(t => t.pdf_id);
            
            CreateTable(
                "dbo.PDFs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        filename = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Annotations", "pdf_id", "dbo.PDFs");
            DropIndex("dbo.Annotations", new[] { "pdf_id" });
            DropTable("dbo.PDFs");
            DropTable("dbo.Annotations");
        }
    }
}
