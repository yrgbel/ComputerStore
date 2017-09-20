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

    // ProductManufacturer
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.32.0.0")]
    public class ProductManufacturerConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<ProductManufacturer>
    {
        public ProductManufacturerConfiguration()
            : this("dbo")
        {
        }

        public ProductManufacturerConfiguration(string schema)
        {
            ToTable("ProductManufacturer", schema);
            HasKey(x => x.ProductManufacturerId);

            Property(x => x.ProductManufacturerId).HasColumnName(@"ProductManufacturerId").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.ProductManufacturerCountry).HasColumnName(@"ProductManufacturerCountry").HasColumnType("nvarchar").IsOptional().HasMaxLength(20);
        }
    }

}
// </auto-generated>
