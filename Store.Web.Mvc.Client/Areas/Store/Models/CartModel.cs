using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Web.Mvc.Client.Areas.Store.Models
{
    public class CartModel
    {
        public IEnumerable<CartItemModel> Items = Enumerable.Empty<CartItemModel>();

        public decimal GrandTotal { get; set; }

        public CartModel()
        {
            GrandTotal = 0m;
        }
    }
}