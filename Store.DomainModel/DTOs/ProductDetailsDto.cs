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
        public string ProductBrandCountry { get; set; } // ProductBrandCountry
        public string ProductManufacturerCountry { get; set; } // ProductManufacturerCountry
        public string ProductSubCategoryName { get; set; } // ProductSubCategoryName
        public string ProductCategoryName { get; set; } // ProductCategoryName
        public string ProductImageLargeUrl { get; set; }
        public string ProductImageSmallUrl { get; set; }
        public string ProductImageThumbnail { get; set; }
        public int ProductOrderCount { get; set; } 

        public string GetDiscountInfoFull => ProductDiscount == null || ProductDiscount == 0
            ? string.Empty : GetDiscountInfoShort + " OFF";
        // The non-breaking space has character code 160: "\u00A0"
        public string GetDiscountInfoShort => ProductDiscount == null || ProductDiscount == 0
            ? string.Empty : 
            $"{(ProductDiscount.ToString().Length == 1 ? "\u00A0" : "")}{ProductDiscount}%";
    }
}