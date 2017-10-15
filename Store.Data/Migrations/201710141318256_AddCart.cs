namespace Store.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        CartId = c.Int(nullable: false, identity: true),
                        CartCookie = c.String(nullable: false, maxLength: 40),
                        CartDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        CartItemCount = c.Int(nullable: false, defaultValue: 0),
                        CartCreatedOn = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        CartCreatedBy = c.Int(),
                        CartChangedOn = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        CartChangedBy = c.Int()
                })
                .PrimaryKey(t => t.CartId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cart");
        }
    }
}
