using System.Collections.Generic;
using System.Linq;
using Store.DomainModel.DTOs;

namespace Store.DomainModel.Model
{
    public class Cart
    {
        private readonly List<CartLine> _lineCollection = new List<CartLine>();

        public void AddItem(ProductDetailsDto product, int quantity)
        {
            CartLine line = _lineCollection
                .FirstOrDefault(p => p.Product.ProductId == product.ProductId);

            if (line == null)
            {
                _lineCollection.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(ProductDetailsDto product)
        {
            _lineCollection.RemoveAll(l => l.Product.ProductId == product.ProductId);
        }

        public decimal ComputeTotalValue()
        {
            return _lineCollection.Sum(e => e.Product.ProductPrice * e.Quantity);

        }
        public void Clear()
        {
            _lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines => _lineCollection;
    }

    public class CartLine
    {
        public ProductDetailsDto Product { get; set; }
        public int Quantity { get; set; }
    }
}