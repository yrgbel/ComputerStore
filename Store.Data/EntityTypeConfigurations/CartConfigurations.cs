using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Store.Model.POCO_Entities;

namespace Store.Data.EntityTypeConfigurations
{
    public class CartConfigurations : EntityTypeConfiguration<Cart>
    {
        public CartConfigurations()
            : this("dbo")
        {
        }
        public CartConfigurations(string schema)
        {
            ToTable("Cart", schema);
            HasKey(x => x.CartId);

            Property(x => x.CartId).HasColumnName(@"CartId").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CartCookie).HasColumnName(@"CartCookie").HasColumnType("nvarchar").HasMaxLength(40).IsRequired();
            Property(x => x.CartDate).HasColumnName(@"CartDate").HasColumnType("datetime").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.CartItemCount).HasColumnName(@"CartItemCount").HasColumnType("int").IsRequired();
            Property(x => x.CartCreatedOn).HasColumnName(@"CartCreatedOn").HasColumnType("datetime").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.CartCreatedBy).HasColumnName(@"CartCreatedBy").HasColumnType("int").IsOptional();
            Property(x => x.CartChangedOn).HasColumnName(@"CartChangedOn").HasColumnType("datetime").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.CartChangedBy).HasColumnName(@"CartChangedBy").HasColumnType("int").IsOptional();
        }
    }
}
