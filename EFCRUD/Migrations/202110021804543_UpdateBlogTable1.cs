namespace EFCRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class UpdateBlogTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "CreateOn", c => c.DateTime(nullable: true));
            AddColumn("dbo.Blogs", "UpadateOn", c => c.DateTime(nullable: true));
            DropColumn("dbo.Blogs", "DateCreated");
            DropColumn("dbo.Blogs", "DateUpdated");
        }

        public override void Down()
        {
            AddColumn("dbo.Blogs", "DateUpdated", c => c.DateTime(nullable: true));
            AddColumn("dbo.Blogs", "DateCreated", c => c.DateTime(nullable: true));
            DropColumn("dbo.Blogs", "UpadateOn");
            DropColumn("dbo.Blogs", "CreateOn");
        }
    }
}
