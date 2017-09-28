namespace Store.DomainModel.DTOs
{
    public class OrderDetailDto : ProductDetailsDto
    {
        public long OrderProductId { get; set; }
        public decimal OrderDetailsQuantity { get; set; }
        public decimal OrderDetailsPrice { get; set; }
        public decimal? OrderDetailsDiscountPrice { get; set; }
    }
}
