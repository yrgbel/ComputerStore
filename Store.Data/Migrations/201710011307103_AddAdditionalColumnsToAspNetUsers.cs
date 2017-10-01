namespace Store.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdditionalColumnsToAspNetUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "SignupDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "CreatedBy", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "ChangedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "ChangedBy", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ChangedBy");
            DropColumn("dbo.AspNetUsers", "ChangedOn");
            DropColumn("dbo.AspNetUsers", "CreatedBy");
            DropColumn("dbo.AspNetUsers", "CreatedOn");
            DropColumn("dbo.AspNetUsers", "SignupDate");
        }
    }
}
