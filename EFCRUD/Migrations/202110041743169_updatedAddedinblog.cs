namespace EFCRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class updatedAddedinblog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "UsersId", c => c.Int(nullable: false, defaultValue: 1));
            CreateIndex("dbo.Blogs", "UsersId");
            AddForeignKey("dbo.Blogs", "UsersId", "dbo.Users", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Blogs", "UsersId", "dbo.Users");
            DropIndex("dbo.Blogs", new[] { "UsersId" });
            DropColumn("dbo.Blogs", "UsersId");
        }
    }
}
