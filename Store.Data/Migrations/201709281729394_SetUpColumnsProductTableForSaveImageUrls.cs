namespace Store.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetUpColumnsProductTableForSaveImageUrls : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "ProductImageUrl", c => c.String(maxLength: 256));
            AlterColumn("dbo.Product", "ProductMiniatureImageUrl", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "ProductMiniatureImageUrl", c => c.String());
            AlterColumn("dbo.Product", "ProductImageUrl", c => c.String());
        }
    }
}
