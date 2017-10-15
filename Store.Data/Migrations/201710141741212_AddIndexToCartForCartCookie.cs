namespace Store.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIndexToCartForCartCookie : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Cart", "CartCookie");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Cart", new[] { "CartCookie" });
        }
    }
}
