namespace Store.DomainModel.DTOs
{
    public class OrderProductDto
    {
        public long OrderProductId { get; set; }
        public long OrderProductNumber { get; set; }
        public System.DateTime OrderProductDate { get; set; }
        public decimal OrderProductTotalQuantity { get; set; }
        public decimal OrderProductTotalPrice { get; set; }
        public int CustomerId { get; set; }

        // Reverse navigation

        /// <summary>
        /// Child OrderDetails where [OrderDetails].[OrderProductId] point to this entity (OrderProduct_OrderDetails)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<OrderDetailDto> OrderDetails { get; set; } // OrderDetails.OrderProduct_OrderDetails

        // Foreign keys

        /// <summary>
        /// Parent Customer pointed by [OrderProduct].([CustomerId]) (Customer_OrderProduct)
        /// </summary>
        public virtual CustomerDto Customer { get; set; } // Customer_OrderProduct

        public OrderProductDto()
        {
            OrderDetails = new System.Collections.Generic.List<OrderDetailDto>();
        }
    }
}
