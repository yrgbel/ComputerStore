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

    // OrderDetails
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.32.0.0")]
    public class OrderDetailConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<OrderDetail>
    {
        public OrderDetailConfiguration()
            : this("dbo")
        {
        }

        public OrderDetailConfiguration(string schema)
        {
            ToTable("OrderDetails", schema);
            HasKey(x => new { x.OrderProductId, x.ProductId });

            Property(x => x.OrderProductId).HasColumnName(@"OrderProductId").HasColumnType("bigint").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.ProductId).HasColumnName(@"ProductId").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.OrderDetailsQuantity).HasColumnName(@"OrderDetailsQuantity").HasColumnType("decimal").IsRequired().HasPrecision(22,4);
            Property(x => x.OrderDetailsPrice).HasColumnName(@"OrderDetailsPrice").HasColumnType("decimal").IsRequired().HasPrecision(22,4);
            Property(x => x.OrderDetailsDiscountPrice).HasColumnName(@"OrderDetailsDiscountPrice").HasColumnType("decimal").IsOptional().HasPrecision(22,4);

            // Foreign keys
            HasRequired(a => a.OrderProduct).WithMany(b => b.OrderDetails).HasForeignKey(c => c.OrderProductId); // OrderProduct_OrderDetails
            HasRequired(a => a.Product).WithMany(b => b.OrderDetails).HasForeignKey(c => c.ProductId); // Product_OrderDetails
        }
    }

}
// </auto-generated>