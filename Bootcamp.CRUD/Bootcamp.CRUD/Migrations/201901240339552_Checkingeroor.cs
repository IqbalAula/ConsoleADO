namespace Bootcamp.CRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Checkingeroor : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Items", name: "supplier_Id", newName: "Suppliers_Id");
            RenameIndex(table: "dbo.Items", name: "IX_supplier_Id", newName: "IX_Suppliers_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Items", name: "IX_Suppliers_Id", newName: "IX_supplier_Id");
            RenameColumn(table: "dbo.Items", name: "Suppliers_Id", newName: "supplier_Id");
        }
    }
}
