namespace EFCRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class createdbyAddedinblog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "createdby", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.Blogs", "createdby");
        }
    }
}
