namespace Store.DomainModel.DTOs
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public byte[] ProductImage { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductQuanity { get; set; }
        public int? ProductBrandId { get; set; }
        public int? ProductManufacturerId { get; set; }
        public string ProductCode { get; set; }
        public int ProductSubCategoryId { get; set; }
        public int ProductCategoryId { get; set; }
        public int? ProductDiscount { get; set; }

        // Reverse navigation

        /// <summary>
        /// Child OrderDetails where [OrderDetails].[ProductId] point to this entity (Product_OrderDetails)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<OrderDetailDto> OrderDetails { get; set; } // OrderDetails.Product_OrderDetails

        // Foreign keys

        /// <summary>
        /// Parent ProductBrand pointed by [Product].([ProductBrandId]) (ProductBrand_Product)
        /// </summary>
        public virtual ProductBrandDto ProductBrand { get; set; } // ProductBrand_Product

        /// <summary>
        /// Parent ProductManufacturer pointed by [Product].([ProductManufacturerId]) (ProductManufacterer_Product)
        /// </summary>
        public virtual ProductManufacturerDto ProductManufacturer { get; set; } // ProductManufacterer_Product

        /// <summary>
        /// Parent ProductSubCategory pointed by [Product].([ProductSubCategoryId], [ProductCategoryId]) (ProductSubCategory_Product)
        /// </summary>
        public virtual ProductSubCategoryDto ProductSubCategory { get; set; } // ProductSubCategory_Product

        public ProductDto()
        {
            OrderDetails = new System.Collections.Generic.List<OrderDetailDto>();
        }
    }
}