namespace Store.DomainModel.DTOs
{
    public class OrderDetailDto
    {
        public long OrderProductId { get; set; }
        public int ProductId { get; set; }
        public decimal OrderDetailsQuantity { get; set; }
        public decimal OrderDetailsPrice { get; set; }
        public decimal? OrderDetailsDiscountPrice { get; set; }
        public virtual OrderProductDto OrderProduct { get; set; } // OrderProduct_OrderDetails
        public virtual ProductDto Product { get; set; } // Product_OrderDetails
    }
}
