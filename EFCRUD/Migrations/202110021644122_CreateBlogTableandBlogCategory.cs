namespace EFCRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class CreateBlogTableandBlogCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogCategories",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Category = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Blogs",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Title = c.String(nullable: false),
                    ShortDescription = c.String(nullable: false),
                    Description = c.String(nullable: false),
                    image = c.String(),
                    CreateOn = c.DateTime(nullable: false, defaultValue: DateTime.UtcNow),
                    Upadate = c.DateTime(nullable: false, defaultValue: DateTime.UtcNow),
                    BlogCategoryId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BlogCategories", t => t.BlogCategoryId, cascadeDelete: true)
                .Index(t => t.BlogCategoryId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Blogs", "BlogCategoryId", "dbo.BlogCategories");
            DropIndex("dbo.Blogs", new[] { "BlogCategoryId" });
            DropTable("dbo.Blogs");
            DropTable("dbo.BlogCategories");
        }
    }
}
