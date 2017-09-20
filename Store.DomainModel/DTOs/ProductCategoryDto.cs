namespace Store.DomainModel.DTOs
{
    public class ProductCategoryDto
    {
        public int ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }

        // Reverse navigation

        /// <summary>
        /// Child ProductSubCategories where [ProductSubCategory].[ProductCategoryId] point to this entity (ProductCategory_ProductSubCategory)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<ProductSubCategoryDto> ProductSubCategories { get; set; } // ProductSubCategory.ProductCategory_ProductSubCategory

        public ProductCategoryDto()
        {
            ProductSubCategories = new System.Collections.Generic.List<ProductSubCategoryDto>();
        }
    }
}