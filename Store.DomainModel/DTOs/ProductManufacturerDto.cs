namespace Store.DomainModel.DTOs
{
    public class ProductManufacturerDto
    {
        public int ProductManufacturerId { get; set; }
        public string ProductManufacturerCountry { get; set; }

        // Reverse navigation

        /// <summary>
        /// Child Products where [Product].[ProductManufacturerId] point to this entity (ProductManufacterer_Product)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<ProductDto> Products { get; set; } // Product.ProductManufacterer_Product

        public ProductManufacturerDto()
        {
            Products = new System.Collections.Generic.List<ProductDto>();
        }
    }
}
