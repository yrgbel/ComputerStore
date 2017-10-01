namespace Store.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnsToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CreatedBy", c => c.Int());
            AddColumn("dbo.AspNetUsers", "ChangedBy", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ChangedBy");
            DropColumn("dbo.AspNetUsers", "CreatedBy");
        }
    }
}
