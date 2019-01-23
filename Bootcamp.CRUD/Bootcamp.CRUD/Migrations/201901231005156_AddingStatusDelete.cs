namespace Bootcamp.CRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingStatusDelete : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Suppliers", "isDelete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Suppliers", "isDelete");
        }
    }
}
