// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.6

using System.Data.Entity;
using Store.Data.Context;

#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace Store.Data
{

    using System.Linq;

    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.32.0.0")]
    public class StoreDbContext : System.Data.Entity.DbContext, IStoreDbContext
    {
        public System.Data.Entity.DbSet<CusomerPhone> CusomerPhones { get; set; } // CusomerPhone
        public System.Data.Entity.DbSet<Customer> Customers { get; set; } // Customer
        public System.Data.Entity.DbSet<OrderDetail> OrderDetails { get; set; } // OrderDetails
        public System.Data.Entity.DbSet<OrderProduct> OrderProducts { get; set; } // OrderProduct
        public System.Data.Entity.DbSet<Product> Products { get; set; } // Product
        public System.Data.Entity.DbSet<ProductBrand> ProductBrands { get; set; } // ProductBrand
        public System.Data.Entity.DbSet<ProductCategory> ProductCategories { get; set; } // ProductCategory
        public System.Data.Entity.DbSet<ProductManufacturer> ProductManufacturers { get; set; } // ProductManufacturer
        public System.Data.Entity.DbSet<ProductSubCategory> ProductSubCategories { get; set; } // ProductSubCategory

        static StoreDbContext()
        {
           Database.SetInitializer<StoreDbContext>(new StoreDbInitializer());
        }

        public StoreDbContext()
            : base("Name=Store")
        {
        }

        public StoreDbContext(string connectionString)
            : base(connectionString)
        {
        }

        public StoreDbContext(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model)
            : base(connectionString, model)
        {
        }

        public StoreDbContext(System.Data.Common.DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
        }

        public StoreDbContext(System.Data.Common.DbConnection existingConnection, System.Data.Entity.Infrastructure.DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public bool IsSqlParameterNull(System.Data.SqlClient.SqlParameter param)
        {
            var sqlValue = param.SqlValue;
            var nullableValue = sqlValue as System.Data.SqlTypes.INullable;
            if (nullableValue != null)
                return nullableValue.IsNull;
            return (sqlValue == null || sqlValue == System.DBNull.Value);
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new CusomerPhoneConfiguration());
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new OrderDetailConfiguration());
            modelBuilder.Configurations.Add(new OrderProductConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new ProductBrandConfiguration());
            modelBuilder.Configurations.Add(new ProductCategoryConfiguration());
            modelBuilder.Configurations.Add(new ProductManufacturerConfiguration());
            modelBuilder.Configurations.Add(new ProductSubCategoryConfiguration());
        }

        public static System.Data.Entity.DbModelBuilder CreateModel(System.Data.Entity.DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new CusomerPhoneConfiguration(schema));
            modelBuilder.Configurations.Add(new CustomerConfiguration(schema));
            modelBuilder.Configurations.Add(new OrderDetailConfiguration(schema));
            modelBuilder.Configurations.Add(new OrderProductConfiguration(schema));
            modelBuilder.Configurations.Add(new ProductConfiguration(schema));
            modelBuilder.Configurations.Add(new ProductBrandConfiguration(schema));
            modelBuilder.Configurations.Add(new ProductCategoryConfiguration(schema));
            modelBuilder.Configurations.Add(new ProductManufacturerConfiguration(schema));
            modelBuilder.Configurations.Add(new ProductSubCategoryConfiguration(schema));
            return modelBuilder;
        }
    }
}
// </auto-generated>
