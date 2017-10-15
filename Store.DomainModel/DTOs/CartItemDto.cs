using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DomainModel.DTOs
{
    public class CartItemDto
    {
        public int CartItemId { get; set; }
        public int CartId { get; set; }
        public int? ProductId { get; set; }
        public decimal CartItemPrice { get; set; }
        public int CartItemQuantity { get; set; }
        public DateTime CartItemCreatedOn { get; set; }
        public int CartItemCreatedBy { get; set; }
        public DateTime CartItemChangedOn { get; set; }
        public int CartItemChangedBy { get; set; }
    }
}
