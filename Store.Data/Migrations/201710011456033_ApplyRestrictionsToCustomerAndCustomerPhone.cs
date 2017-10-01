namespace Store.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyRestrictionsToCustomerAndCustomerPhone : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerPhone", "CustomerPhoneNumber", c => c.String(nullable: false, maxLength: 15, unicode: false));
            AlterColumn("dbo.Customer", "CustomerAddress", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Customer", "CustomerCity", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Customer", "CustomerCountry", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customer", "CustomerCountry", c => c.String(maxLength: 20));
            AlterColumn("dbo.Customer", "CustomerCity", c => c.String(maxLength: 15));
            AlterColumn("dbo.Customer", "CustomerAddress", c => c.String(maxLength: 50));
            AlterColumn("dbo.CustomerPhone", "CustomerPhoneNumber", c => c.String(maxLength: 15, unicode: false));
        }
    }
}
