namespace EFCRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBlogTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "DateCreated", c => c.DateTime(nullable: true,defaultValue:DateTime.Now));
            AddColumn("dbo.Blogs", "DateUpdated", c => c.DateTime(nullable: true, defaultValue: DateTime.Now));
            DropColumn("dbo.Blogs", "CreateOn");
            DropColumn("dbo.Blogs", "Upadate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "Upadate", c => c.DateTime(nullable: true, defaultValue: DateTime.Now));
            AddColumn("dbo.Blogs", "CreateOn", c => c.DateTime(nullable: true, defaultValue: DateTime.Now));
            DropColumn("dbo.Blogs", "DateUpdated");
            DropColumn("dbo.Blogs", "DateCreated");
        }
    }
}
