namespace Store.DomainModel.DTOs
{
    public class OrderDetailDto
    {
        public long OrderProductId { get; set; }
        public int ProductId { get; set; }
        public decimal OrderDetailsQuantity { get; set; }
        public decimal OrderDetailsPrice { get; set; }
        public decimal? OrderDetailsDiscountPrice { get; set; }

        // Foreign keys

        /// <summary>
        /// Parent OrderProduct pointed by [OrderDetails].([OrderProductId]) (OrderProduct_OrderDetails)
        /// </summary>
        public virtual OrderProductDto OrderProduct { get; set; } // OrderProduct_OrderDetails

        /// <summary>
        /// Parent Product pointed by [OrderDetails].([ProductId]) (Product_OrderDetails)
        /// </summary>
        public virtual ProductDto Product { get; set; } // Product_OrderDetails
    }
}
