namespace EFCRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class ReviewTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reviews",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Reviews = c.String(nullable: false),
                    Rating = c.Int(nullable: false),
                    BlogId = c.Int(nullable: false),
                    UserId = c.Int(nullable: false),
                    Date = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Blogs", t => t.BlogId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.BlogId)
                .Index(t => t.UserId);

            AddColumn("dbo.Users", "Course_Id", c => c.Int());
            AddColumn("dbo.Users", "Student_Id", c => c.Int());
            CreateIndex("dbo.Users", "Course_Id");
            CreateIndex("dbo.Users", "Student_Id");
            AddForeignKey("dbo.Users", "Course_Id", "dbo.Courses", "Id");
            AddForeignKey("dbo.Users", "Student_Id", "dbo.Students", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Users", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Reviews", "BlogId", "dbo.Blogs");
            DropIndex("dbo.Users", new[] { "Student_Id" });
            DropIndex("dbo.Users", new[] { "Course_Id" });
            DropIndex("dbo.Reviews", new[] { "UserId" });
            DropIndex("dbo.Reviews", new[] { "BlogId" });
            DropColumn("dbo.Users", "Student_Id");
            DropColumn("dbo.Users", "Course_Id");
            DropTable("dbo.Reviews");
        }
    }
}
