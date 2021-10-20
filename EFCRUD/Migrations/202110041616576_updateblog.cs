namespace EFCRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class updateblog : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blogs", "CreateOn", c => c.DateTime());
            AlterColumn("dbo.Blogs", "UpadateOn", c => c.DateTime());
        }

        public override void Down()
        {
            AlterColumn("dbo.Blogs", "UpadateOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Blogs", "CreateOn", c => c.DateTime(nullable: false));
        }
    }
}
