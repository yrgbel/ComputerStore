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
        public string ProductImageMimeType { get; set; }

        /// <summary>
        /// Parent ProductBrand pointed by [Product].([ProductBrandId]) (ProductBrand_Product)
        /// </summary>
        //public string ProductBrandName { get; set; }
        //public string ProductBrandCountry { get; set; }
        public ProductBrandDto ProductBrand { get; set; }

        /// <summary>
        /// Parent ProductManufacturer pointed by [Product].([ProductManufacturerId]) (ProductManufacterer_Product)
        /// </summary>
        public string ProductManufacturerCountry { get; set; }

        /// <summary>
        /// Parent ProductSubCategory pointed by [Product].([ProductSubCategoryId], [ProductCategoryId]) (ProductSubCategory_Product)
        /// </summary>
        public string ProductSubCategoryName { get; set; }
        public string ProductCategoryName { get; set; }
    }
}