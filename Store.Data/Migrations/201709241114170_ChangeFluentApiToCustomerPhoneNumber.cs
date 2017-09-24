namespace Store.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFluentApiToCustomerPhoneNumber : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CusomerPhone", "CustomerPhoneNumber", c => c.String(maxLength: 15, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CusomerPhone", "CustomerPhoneNumber", c => c.String(maxLength: 10, unicode: false));
        }
    }
}
