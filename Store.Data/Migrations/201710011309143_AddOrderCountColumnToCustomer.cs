namespace Store.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderCountColumnToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "OrderCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customer", "OrderCount");
        }
    }
}
