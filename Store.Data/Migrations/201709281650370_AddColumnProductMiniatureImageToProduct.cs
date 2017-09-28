namespace Store.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnProductMiniatureImageToProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "ProductMiniatureImage", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "ProductMiniatureImage");
        }
    }
}
