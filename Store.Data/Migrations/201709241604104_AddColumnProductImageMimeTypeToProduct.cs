namespace Store.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnProductImageMimeTypeToProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "ProductImageMimeType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "ProductImageMimeType");
        }
    }
}
