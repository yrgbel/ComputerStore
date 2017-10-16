using System;

namespace Store.Model.POCO_Entities
{
    public class CartItem
    {
        public int CartItemId { get; set; } // CartItemId (Primary key)
        public Cart Cart { get; set; }
        public int CartId { get; set; } // CartId (Foreign key)
        public int ProductId { get; set; }
        public decimal CartItemPrice { get; set; }
        public int CartItemQuantity { get; set; }
        public DateTime CartItemCreatedOn { get; set; }
        public int CartItemCreatedBy { get; set; }
        public DateTime CartItemChangedOn { get; set; }
        public int CartItemChangedBy { get; set; }
    }
}
