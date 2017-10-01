namespace Store.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveColumnsFromApplicationUserForRecreate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "CreatedBy");
            DropColumn("dbo.AspNetUsers", "ChangedBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "ChangedBy", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "CreatedBy", c => c.DateTime(nullable: false));
        }
    }
}
