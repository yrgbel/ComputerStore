namespace Store.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CusomerPhone",
                c => new
                    {
                        CustomerPhoneId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        CustomerPhoneNumber = c.String(maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => new { t.CustomerPhoneId, t.CustomerId })
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false, maxLength: 30, unicode: false),
                        CustomerEmail = c.String(nullable: false, maxLength: 50, unicode: false),
                        CustomerPatronymic = c.String(maxLength: 40, unicode: false),
                        CustomerLastName = c.String(nullable: false, maxLength: 40, unicode: false),
                        UserId = c.Int(),
                        CustomerAddress = c.String(maxLength: 50),
                        CustomerCity = c.String(maxLength: 15),
                        CustomerRegion = c.String(maxLength: 20),
                        CustomerCountry = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.OrderProduct",
                c => new
                    {
                        OrderProductId = c.Long(nullable: false, identity: true),
                        OrderProductNumber = c.Long(nullable: false),
                        OrderProductDate = c.DateTime(nullable: false),
                        OrderProductTotalQuantity = c.Decimal(nullable: false, precision: 22, scale: 4),
                        OrderProductTotalPrice = c.Decimal(nullable: false, precision: 22, scale: 4),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderProductId)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderProductId = c.Long(nullable: false),
                        ProductId = c.Int(nullable: false),
                        OrderDetailsQuantity = c.Decimal(nullable: false, precision: 22, scale: 4),
                        OrderDetailsPrice = c.Decimal(nullable: false, precision: 22, scale: 4),
                        OrderDetailsDiscountPrice = c.Decimal(precision: 22, scale: 4),
                    })
                .PrimaryKey(t => new { t.OrderProductId, t.ProductId })
                .ForeignKey("dbo.OrderProduct", t => t.OrderProductId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderProductId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 50),
                        ProductPrice = c.Decimal(nullable: false, storeType: "money"),
                        ProductImage = c.Binary(),
                        ProductDescription = c.String(),
                        ProductQuanity = c.Decimal(nullable: false, precision: 22, scale: 4),
                        ProductBrandId = c.Int(),
                        ProductManufacturerId = c.Int(),
                        ProductCode = c.String(maxLength: 40, unicode: false),
                        ProductSubCategoryId = c.Int(nullable: false),
                        ProductCategoryId = c.Int(nullable: false),
                        ProductDiscount = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.ProductBrand", t => t.ProductBrandId)
                .ForeignKey("dbo.ProductManufacturer", t => t.ProductManufacturerId)
                .ForeignKey("dbo.ProductSubCategory", t => new { t.ProductSubCategoryId, t.ProductCategoryId })
                .Index(t => t.ProductBrandId)
                .Index(t => t.ProductManufacturerId)
                .Index(t => new { t.ProductSubCategoryId, t.ProductCategoryId });
            
            CreateTable(
                "dbo.ProductBrand",
                c => new
                    {
                        ProductBrandId = c.Int(nullable: false, identity: true),
                        ProductBrandName = c.String(maxLength: 25),
                        ProductBrandCountry = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.ProductBrandId);
            
            CreateTable(
                "dbo.ProductManufacturer",
                c => new
                    {
                        ProductManufacturerId = c.Int(nullable: false, identity: true),
                        ProductManufacturerCountry = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.ProductManufacturerId);
            
            CreateTable(
                "dbo.ProductSubCategory",
                c => new
                    {
                        ProductSubCategoryId = c.Int(nullable: false, identity: true),
                        ProductCategoryId = c.Int(nullable: false),
                        ProductSubCategoryName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.ProductSubCategoryId, t.ProductCategoryId })
                .ForeignKey("dbo.ProductCategory", t => t.ProductCategoryId)
                .Index(t => t.ProductCategoryId);
            
            CreateTable(
                "dbo.ProductCategory",
                c => new
                    {
                        ProductCategoryId = c.Int(nullable: false, identity: true),
                        ProductCategoryName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ProductCategoryId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.CusomerPhone", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Product", new[] { "ProductSubCategoryId", "ProductCategoryId" }, "dbo.ProductSubCategory");
            DropForeignKey("dbo.ProductSubCategory", "ProductCategoryId", "dbo.ProductCategory");
            DropForeignKey("dbo.Product", "ProductManufacturerId", "dbo.ProductManufacturer");
            DropForeignKey("dbo.Product", "ProductBrandId", "dbo.ProductBrand");
            DropForeignKey("dbo.OrderDetails", "OrderProductId", "dbo.OrderProduct");
            DropForeignKey("dbo.OrderProduct", "CustomerId", "dbo.Customer");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ProductSubCategory", new[] { "ProductCategoryId" });
            DropIndex("dbo.Product", new[] { "ProductSubCategoryId", "ProductCategoryId" });
            DropIndex("dbo.Product", new[] { "ProductManufacturerId" });
            DropIndex("dbo.Product", new[] { "ProductBrandId" });
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderProductId" });
            DropIndex("dbo.OrderProduct", new[] { "CustomerId" });
            DropIndex("dbo.CusomerPhone", new[] { "CustomerId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ProductCategory");
            DropTable("dbo.ProductSubCategory");
            DropTable("dbo.ProductManufacturer");
            DropTable("dbo.ProductBrand");
            DropTable("dbo.Product");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.OrderProduct");
            DropTable("dbo.Customer");
            DropTable("dbo.CusomerPhone");
        }
    }
}
