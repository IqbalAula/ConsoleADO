namespace Bootcamp.CRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVirtualIdSupplierAndUpdateItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "Stock", c => c.Int(nullable: false));
            AddColumn("dbo.Items", "supplier_Id", c => c.Int());
            CreateIndex("dbo.Items", "supplier_Id");
            AddForeignKey("dbo.Items", "supplier_Id", "dbo.Suppliers", "Id");
            DropColumn("dbo.Items", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "Quantity", c => c.Int(nullable: false));
            DropForeignKey("dbo.Items", "supplier_Id", "dbo.Suppliers");
            DropIndex("dbo.Items", new[] { "supplier_Id" });
            DropColumn("dbo.Items", "supplier_Id");
            DropColumn("dbo.Items", "Stock");
        }
    }
}
