using System.Collections.Generic;

namespace Store.DomainModel.DTOs
{
    public class ProductCategoryDto
    {
        public int ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }
        public virtual ICollection<ProductSubCategoryDto> ProductSubCategories { get; set; } // ProductSubCategory.ProductCategory_ProductSubCategory

        public ProductCategoryDto()
        {
            ProductSubCategories = new List<ProductSubCategoryDto>();
        }
    }
}