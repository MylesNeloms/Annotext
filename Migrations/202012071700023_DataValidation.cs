namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Annotations", "content", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Annotations", "content", c => c.String());
        }
    }
}
