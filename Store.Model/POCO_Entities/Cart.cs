using System;
using System.Collections.Generic;

namespace Store.Model.POCO_Entities
{
    public class Cart
    {
        public Cart()
        {
            CartItems = new List<CartItem>();
        }
        public int CartId { get; set; } // CartId (Primary key)
        public string CartCookie { get; set; }
        public DateTime CartDate { get; set; }
        public int CartItemCount { get; set; }
        public DateTime CartCreatedOn { get; set; }
        public int CartCreatedBy { get; set; }
        public DateTime CartChangedOn { get; set; }
        public int CartChangedBy { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
