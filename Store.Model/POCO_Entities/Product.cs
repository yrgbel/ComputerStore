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


namespace Store.Model.POCO_Entities
{

    // Product
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.32.0.0")]
    public class Product
    {
        public int ProductId { get; set; } // ProductId (Primary key)
        public string ProductName { get; set; } // ProductName (length: 50)
        public decimal ProductPrice { get; set; } // ProductPrice
        public byte[] ProductImage { get; set; } // ProductImage
        public string ProductDescription { get; set; } // ProductDescription
        public decimal ProductQuanity { get; set; } // ProductQuanity
        public int? ProductBrandId { get; set; } // ProductBrandId
        public int? ProductManufacturerId { get; set; } // ProductManufacturerId
        public string ProductCode { get; set; } // ProductCode (length: 40)
        public int ProductSubCategoryId { get; set; } // ProductSubCategoryId
        public int ProductCategoryId { get; set; } // ProductCategoryId
        public int? ProductDiscount { get; set; } // ProductDiscount
        public string ProductImageMimeType { get; set; } // ProductImageMimeType

        // Reverse navigation

        /// <summary>
        /// Child OrderDetails where [OrderDetails].[ProductId] point to this entity (Product_OrderDetails)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<OrderDetail> OrderDetails { get; set; } // OrderDetails.Product_OrderDetails

        // Foreign keys

        /// <summary>
        /// Parent ProductBrand pointed by [Product].([ProductBrandId]) (ProductBrand_Product)
        /// </summary>
        public virtual ProductBrand ProductBrand { get; set; } // ProductBrand_Product

        /// <summary>
        /// Parent ProductManufacturer pointed by [Product].([ProductManufacturerId]) (ProductManufacterer_Product)
        /// </summary>
        public virtual ProductManufacturer ProductManufacturer { get; set; } // ProductManufacterer_Product

        /// <summary>
        /// Parent ProductSubCategory pointed by [Product].([ProductSubCategoryId], [ProductCategoryId]) (ProductSubCategory_Product)
        /// </summary>
        public virtual ProductSubCategory ProductSubCategory { get; set; } // ProductSubCategory_Product

        public Product()
        {
            OrderDetails = new System.Collections.Generic.List<OrderDetail>();
        }
    }

}
// </auto-generated>
