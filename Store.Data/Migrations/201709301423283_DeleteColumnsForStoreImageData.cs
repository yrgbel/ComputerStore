namespace Store.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteColumnsForStoreImageData : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Product", "ProductImageName");
            DropColumn("dbo.Product", "ProductImageMimeType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "ProductImageMimeType", c => c.String(maxLength: 15));
            AddColumn("dbo.Product", "ProductImageName", c => c.String(maxLength: 70));
        }
    }
}
