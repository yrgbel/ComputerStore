using System;
using System.Collections.Generic;

namespace Store.DomainModel.DTOs
{
    public class CartDto
    {
        public CartDto()
        {
            CartItems = new List<CartItemDto>();
        }

        public int CartId { get; set; }
        public string CartCookie { get; set; }
        public DateTime CartDate { get; set; }
        public int CartItemCount { get; set; }
        public DateTime CartCreatedOn { get; set; }
        public int CartCreatedBy { get; set; }
        public DateTime CartChangedOn { get; set; }
        public int CartChangedBy { get; set; }
        public ICollection<CartItemDto> CartItems { get; set; }
    }
}
