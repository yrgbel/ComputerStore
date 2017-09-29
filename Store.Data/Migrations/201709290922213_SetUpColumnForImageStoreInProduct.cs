namespace Store.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetUpColumnForImageStoreInProduct : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "ProductImageName", c => c.String(maxLength: 70));
            AlterColumn("dbo.Product", "ProductImageMimeType", c => c.String(maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "ProductImageMimeType", c => c.String());
            AlterColumn("dbo.Product", "ProductImageName", c => c.String());
        }
    }
}
