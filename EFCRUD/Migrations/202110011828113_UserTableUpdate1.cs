namespace EFCRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserTableUpdate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "image", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "image", c => c.String(nullable: false));
        }
    }
}
