namespace Store.Web.Mvc.Client.Areas.Store.Models
{
    public class CartItemModel
    {
        public int CartItemId { get; set; }
        public decimal CartItemPrice { get; set; }
        public int CartItemQuantity { get; set; }
        public int ProductId { get; set; }

        public decimal SubTotal { get; set; }
        public string ProductImageLargeUrl { get; set; }
        public string ProductImageThumbnailUrl { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
    }
}