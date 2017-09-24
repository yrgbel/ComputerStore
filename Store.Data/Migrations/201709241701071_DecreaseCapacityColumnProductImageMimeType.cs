namespace Store.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DecreaseCapacityColumnProductImageMimeType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "ProductImageMimeType", c => c.String(maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "ProductImageMimeType", c => c.String());
        }
    }
}
