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

using Store.Model.POCO_Entities;

#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace Store.Data
{

    // OrderProduct
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.32.0.0")]
    public class OrderProductConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<OrderProduct>
    {
        public OrderProductConfiguration()
            : this("dbo")
        {
        }

        public OrderProductConfiguration(string schema)
        {
            ToTable("OrderProduct", schema);
            HasKey(x => x.OrderProductId);

            Property(x => x.OrderProductId).HasColumnName(@"OrderProductId").HasColumnType("bigint").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.OrderProductNumber).HasColumnName(@"OrderProductNumber").HasColumnType("bigint").IsRequired();
            Property(x => x.OrderProductDate).HasColumnName(@"OrderProductDate").HasColumnType("datetime").IsRequired();
            Property(x => x.OrderProductTotalQuantity).HasColumnName(@"OrderProductTotalQuantity").HasColumnType("decimal").IsRequired().HasPrecision(22,4);
            Property(x => x.OrderProductTotalPrice).HasColumnName(@"OrderProductTotalPrice").HasColumnType("decimal").IsRequired().HasPrecision(22,4);
            Property(x => x.CustomerId).HasColumnName(@"CustomerId").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.Customer).WithMany(b => b.OrderProducts).HasForeignKey(c => c.CustomerId); // Customer_OrderProduct
        }
    }

}
// </auto-generated>
