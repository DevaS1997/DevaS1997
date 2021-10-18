namespace EFCRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserTableUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "firstname", c => c.String(nullable: false));
            AddColumn("dbo.Users", "lastname", c => c.String(nullable: false));
            AddColumn("dbo.Users", "email", c => c.String(nullable: false));
            AddColumn("dbo.Users", "phoneno", c => c.String(nullable: false));
            AddColumn("dbo.Users", "image", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "image");
            DropColumn("dbo.Users", "phoneno");
            DropColumn("dbo.Users", "email");
            DropColumn("dbo.Users", "lastname");
            DropColumn("dbo.Users", "firstname");
        }
    }
}
