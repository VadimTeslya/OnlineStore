using System.Collections.Generic;
using System.Linq;

namespace OnlineStoreEntity
{
    public class Сart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Product product, int quantity)
        {
            CartLine line = lineCollection
                .FirstOrDefault(p => p.Product.Id == product.Id);

            if (line == null)
            {
                lineCollection.Add(new CartLine
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

        public void RemoveLine(Product product)
        {
            lineCollection.RemoveAll(l => l.Product.Id == product.Id);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(l => l.Product.Price * l.Quantity);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

        public ICollection<CartLine> Lines
        {
            get { return lineCollection; }
        }
  }

  public class CartLine
  {
    public Product Product { get; set; }
    public int Quantity { get; set; }
  }
    
}
