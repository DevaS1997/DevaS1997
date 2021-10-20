namespace EFCRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class ratingaddedinblogtable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "rating", c => c.Int());
        }

        public override void Down()
        {
            DropColumn("dbo.Blogs", "rating");
        }
    }
}
