namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Annotations",
                c => new
                    {
                        AnnotationId = c.Int(nullable: false, identity: true),
                        content = c.String(nullable: false),
                        filename = c.String(nullable: false),
                        author = c.String(nullable: false),
                        VoteVal = c.Int(nullable: false),
                        pageNum = c.Int(nullable: false),
                        paragraph = c.Int(nullable: false),
                        PDFId = c.String(),
                        pdf_PDFid = c.Int(),
                    })
                .PrimaryKey(t => t.AnnotationId)
                .ForeignKey("dbo.PDFs", t => t.pdf_PDFid)
                .Index(t => t.pdf_PDFid);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        content = c.String(nullable: false),
                        author = c.String(nullable: false),
                        VoteVal = c.Int(nullable: false),
                        AnnotationId = c.String(),
                        annotation_AnnotationId = c.Int(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Annotations", t => t.annotation_AnnotationId)
                .Index(t => t.annotation_AnnotationId);
            
            CreateTable(
                "dbo.PDFs",
                c => new
                    {
                        PDFid = c.Int(nullable: false, identity: true),
                        filename = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PDFid)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PDFs", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Annotations", "pdf_PDFid", "dbo.PDFs");
            DropForeignKey("dbo.Comments", "annotation_AnnotationId", "dbo.Annotations");
            DropIndex("dbo.PDFs", new[] { "CategoryId" });
            DropIndex("dbo.Comments", new[] { "annotation_AnnotationId" });
            DropIndex("dbo.Annotations", new[] { "pdf_PDFid" });
            DropTable("dbo.Categories");
            DropTable("dbo.PDFs");
            DropTable("dbo.Comments");
            DropTable("dbo.Annotations");
        }
    }
}
