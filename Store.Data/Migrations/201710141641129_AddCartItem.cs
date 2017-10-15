namespace Store.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddCartItem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartItem",
                c => new
                    {
                        CartItemId = c.Int(nullable: false, identity: true),
                        CartId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        CartItemPrice = c.Decimal(nullable: false, storeType: "money"),
                        CartItemQuantity = c.Int(nullable: false, defaultValue: 1),
                        CartItemCreatedOn = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        CartItemCreatedBy = c.Int(),
                        CartItemChangedOn = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        CartItemChangedBy = c.Int(),
                    })
                .PrimaryKey(t => t.CartItemId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CartItem");
        }
    }
}
