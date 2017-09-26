using System.Collections.Generic;

namespace Store.DomainModel.DTOs
{
    public class ProductSubCategoryDto
    {
        public int ProductSubCategoryId { get; set; }
        public string ProductSubCategoryName { get; set; }
        public int ProductCategoryId { get; set; }
        public virtual ICollection<ProductDto> Products { get; set; } // Product.ProductSubCategory_Product
        public virtual ProductCategoryDto ProductCategory { get; set; } // ProductCategory_ProductSubCategory

        public ProductSubCategoryDto()
        {
            Products = new System.Collections.Generic.List<ProductDto>();
        }
    }
}
