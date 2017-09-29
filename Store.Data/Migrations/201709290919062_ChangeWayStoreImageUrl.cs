namespace Store.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeWayStoreImageUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "ProductImageName", c => c.String());
            AddColumn("dbo.Product", "ProductImageMimeType", c => c.String());
            DropColumn("dbo.Product", "ProductImageUrl");
            DropColumn("dbo.Product", "ProductMiniatureImageUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "ProductMiniatureImageUrl", c => c.String(maxLength: 256));
            AddColumn("dbo.Product", "ProductImageUrl", c => c.String(maxLength: 256));
            DropColumn("dbo.Product", "ProductImageMimeType");
            DropColumn("dbo.Product", "ProductImageName");
        }
    }
}
