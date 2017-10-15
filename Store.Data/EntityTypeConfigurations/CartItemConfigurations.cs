using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Store.Model.POCO_Entities;

namespace Store.Data.EntityTypeConfigurations
{
    public class CartItemConfigurations : EntityTypeConfiguration<CartItem>
    {
        public CartItemConfigurations()
            : this("dbo")
        {
        }
        public CartItemConfigurations(string schema)
        {
            ToTable("CartItem", schema);
            HasKey(x => x.CartItemId);

            Property(x => x.CartItemId).HasColumnName(@"CartItemId").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CartId).HasColumnName(@"CartId").HasColumnType("int").IsRequired();
            Property(x => x.ProductId).HasColumnName(@"ProductId").HasColumnType("int").IsRequired();
            Property(x => x.CartItemPrice).HasColumnName(@"CartItemPrice").HasColumnType("money").IsRequired();
            Property(x => x.CartItemQuantity).HasColumnName(@"CartItemQuantity").HasColumnType("int").IsRequired();
            Property(x => x.CartItemCreatedOn).HasColumnName(@"CartItemCreatedOn").HasColumnType("datetime").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.CartItemCreatedBy).HasColumnName(@"CartItemCreatedBy").HasColumnType("int").IsOptional();
            Property(x => x.CartItemChangedOn).HasColumnName(@"CartItemChangedOn").HasColumnType("datetime").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.CartItemChangedBy).HasColumnName(@"CartItemChangedBy").HasColumnType("int").IsOptional();
        }
    }
}
