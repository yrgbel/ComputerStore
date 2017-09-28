namespace Store.DomainModel.DTOs
{
    public class ProductDetailsDto
    {
        public int ProductId { get; set; } // ProductId (Primary key)
        public string ProductName { get; set; } // ProductName
        public decimal ProductPrice { get; set; } // ProductPrice
        public string ProductDescription { get; set; } // ProductDescription
        public decimal ProductQuanity { get; set; } // ProductQuanity
        public string ProductCode { get; set; } // ProductCode
        public int? ProductDiscount { get; set; } // ProductDiscount
        public string ProductBrandName { get; set; } // ProductBrandName
        public byte[] ProductImage { get; set; } // ProductImage
        public string ProductBrandCountry { get; set; } // ProductBrandCountry
        public string ProductManufacturerCountry { get; set; } // ProductManufacturerCountry
        public string ProductSubCategoryName { get; set; } // ProductSubCategoryName
        public string ProductCategoryName { get; set; } // ProductCategoryName
    }
}