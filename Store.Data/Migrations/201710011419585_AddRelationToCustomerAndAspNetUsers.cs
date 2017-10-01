namespace Store.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationToCustomerAndAspNetUsers : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customer", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Customer", "UserId");
            AddForeignKey("dbo.Customer", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customer", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Customer", new[] { "UserId" });
            AlterColumn("dbo.Customer", "UserId", c => c.Int());
        }
    }
}
