namespace EFCRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class updatedbyAddedinblog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "updatedby", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.Blogs", "updatedby");
        }
    }
}
