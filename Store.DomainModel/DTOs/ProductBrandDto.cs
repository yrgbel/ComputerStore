namespace Store.DomainModel.DTOs
{
    public class ProductBrandDto
    {
        public int ProductBrandId { get; set; }
        public string ProductBrandName { get; set; }
        public string ProductBrandCountry { get; set; }

        // Reverse navigation

        /// <summary>
        /// Child Products where [Product].[ProductBrandId] point to this entity (ProductBrand_Product)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<ProductDto> Products { get; set; } // Product.ProductBrand_Product

        public ProductBrandDto()
        {
            Products = new System.Collections.Generic.List<ProductDto>();
        }
    }
}
