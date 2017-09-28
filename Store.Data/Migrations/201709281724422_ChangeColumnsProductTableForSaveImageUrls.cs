namespace Store.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeColumnsProductTableForSaveImageUrls : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "ProductImageUrl", c => c.String());
            AddColumn("dbo.Product", "ProductMiniatureImageUrl", c => c.String());
            DropColumn("dbo.Product", "ProductImage");
            DropColumn("dbo.Product", "ProductImageMimeType");
            DropColumn("dbo.Product", "ProductMiniatureImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "ProductMiniatureImage", c => c.Binary());
            AddColumn("dbo.Product", "ProductImageMimeType", c => c.String(maxLength: 15));
            AddColumn("dbo.Product", "ProductImage", c => c.Binary());
            DropColumn("dbo.Product", "ProductMiniatureImageUrl");
            DropColumn("dbo.Product", "ProductImageUrl");
        }
    }
}
