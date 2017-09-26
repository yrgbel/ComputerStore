namespace Store.DomainModel.DTOs
{
    public class ProductSubCategoryDto
    {
        public int ProductSubCategoryId { get; set; }
        public string ProductSubCategoryName { get; set; }
        public int ProductCategoryId { get; set; }

        // Reverse navigation

        /// <summary>
        /// Child Products where [Product].([ProductCategoryId], [ProductSubCategoryId]) point to this entity (ProductSubCategory_Product)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<ProductDto> Products { get; set; } // Product.ProductSubCategory_Product

        // Foreign keys

        /// <summary>
        /// Parent ProductCategory pointed by [ProductSubCategory].([ProductCategoryId]) (ProductCategory_ProductSubCategory)
        /// </summary>
        public virtual ProductCategoryDto ProductCategory { get; set; } // ProductCategory_ProductSubCategory

        public ProductSubCategoryDto()
        {
            Products = new System.Collections.Generic.List<ProductDto>();
        }
    }
}
