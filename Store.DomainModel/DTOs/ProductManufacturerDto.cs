using System.Collections.Generic;

namespace Store.DomainModel.DTOs
{
    public class ProductManufacturerDto
    {
        public int ProductManufacturerId { get; set; }
        public string ProductManufacturerCountry { get; set; }
        public virtual ICollection<ProductDto> Products { get; set; } // Product.ProductManufacterer_Product

        public ProductManufacturerDto()
        {
            Products = new List<ProductDto>();
        }
    }
}
