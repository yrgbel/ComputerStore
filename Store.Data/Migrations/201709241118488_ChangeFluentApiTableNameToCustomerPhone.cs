namespace Store.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFluentApiTableNameToCustomerPhone : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CusomerPhone", newName: "CustomerPhone");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.CustomerPhone", newName: "CusomerPhone");
        }
    }
}
