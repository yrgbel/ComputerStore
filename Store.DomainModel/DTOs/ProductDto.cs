using System.Collections.Generic;

namespace Store.DomainModel.DTOs
{
    public class ProductDto
    {
        public int ProductId { get; set; } // ProductId (Primary key)
        public string ProductName { get; set; } // ProductName (length: 50)
        public decimal ProductPrice { get; set; } // ProductPrice
        public byte[] ProductImage { get; set; } // ProductImage
        public string ProductDescription { get; set; } // ProductDescription
        public decimal ProductQuanity { get; set; } // ProductQuanity
        public int? ProductBrandId { get; set; } // ProductBrandId
        public int? ProductManufacturerId { get; set; } // ProductManufacturerId
        public string ProductCode { get; set; } // ProductCode (length: 40)
        public int ProductSubCategoryId { get; set; } // ProductSubCategoryId
        public int ProductCategoryId { get; set; } // ProductCategoryId
        public int? ProductDiscount { get; set; } // ProductDiscount
        public string ProductImageMimeType { get; set; } // ProductImageMimeType
        public virtual ICollection<OrderDetailDto> OrderDetails { get; set; } // OrderDetails.Product_OrderDetails

        public ProductDto()
        {
            OrderDetails = new List<OrderDetailDto>();
        }
    }
}