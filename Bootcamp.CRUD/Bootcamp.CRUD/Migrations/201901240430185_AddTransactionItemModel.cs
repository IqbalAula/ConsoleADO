namespace Bootcamp.CRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTransactionItemModel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.TransactionItems", name: "Itemid_Id", newName: "Item_Id");
            RenameColumn(table: "dbo.TransactionItems", name: "TransactionId_Id", newName: "Transaction_Id");
            RenameIndex(table: "dbo.TransactionItems", name: "IX_Itemid_Id", newName: "IX_Item_Id");
            RenameIndex(table: "dbo.TransactionItems", name: "IX_TransactionId_Id", newName: "IX_Transaction_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.TransactionItems", name: "IX_Transaction_Id", newName: "IX_TransactionId_Id");
            RenameIndex(table: "dbo.TransactionItems", name: "IX_Item_Id", newName: "IX_Itemid_Id");
            RenameColumn(table: "dbo.TransactionItems", name: "Transaction_Id", newName: "TransactionId_Id");
            RenameColumn(table: "dbo.TransactionItems", name: "Item_Id", newName: "Itemid_Id");
        }
    }
}
