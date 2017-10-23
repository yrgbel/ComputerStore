using System.Collections.Generic;
using System.Linq;

namespace Store.Web.Mvc.Client.Areas.Store.Models
{
    public class CartModel
    {
        public IEnumerable<CartItemModel> Items { get; set; }

        public decimal GrandTotal { get; set; }

        public CartModel()
        {
            Items = Enumerable.Empty<CartItemModel>();
            GrandTotal = 0m;
        }
    }
}