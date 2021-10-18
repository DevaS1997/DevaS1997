namespace EFCRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class removedforeignkey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Blogs", "UsersId", "dbo.Users");
            DropIndex("dbo.Blogs", new[] { "UsersId" });
            DropColumn("dbo.Blogs", "UsersId");
        }

        public override void Down()
        {
            AddColumn("dbo.Blogs", "UsersId", c => c.Int(nullable: false));
            CreateIndex("dbo.Blogs", "UsersId");
            AddForeignKey("dbo.Blogs", "UsersId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
