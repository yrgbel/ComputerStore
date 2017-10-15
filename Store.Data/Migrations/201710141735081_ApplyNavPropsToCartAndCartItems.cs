namespace Store.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyNavPropsToCartAndCartItems : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.CartItem", "CartId");
            AddForeignKey("dbo.CartItem", "CartId", "dbo.Cart", "CartId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartItem", "CartId", "dbo.Cart");
            DropIndex("dbo.CartItem", new[] { "CartId" });
        }
    }
}
