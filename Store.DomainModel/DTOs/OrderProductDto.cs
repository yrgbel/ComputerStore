using System;
using System.Collections.Generic;

namespace Store.DomainModel.DTOs
{
    public class OrderProductDto
    {
        public long OrderProductId { get; set; }
        public long OrderProductNumber { get; set; }
        public DateTime OrderProductDate { get; set; }
        public decimal OrderProductTotalQuantity { get; set; }
        public decimal OrderProductTotalPrice { get; set; }
        public int CustomerId { get; set; }
        public virtual ICollection<OrderDetailDto> OrderDetails { get; set; } // OrderDetails.OrderProduct_OrderDetails

        public OrderProductDto()
        {
            OrderDetails = new List<OrderDetailDto>();
        }
    }
}
