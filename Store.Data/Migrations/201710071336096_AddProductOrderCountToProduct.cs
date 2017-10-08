namespace Store.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductOrderCountToProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "ProductOrderCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "ProductOrderCount");
        }
    }
}
