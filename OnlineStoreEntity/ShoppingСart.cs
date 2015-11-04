using System.Collections.Generic;

namespace OnlineStoreEntity
{
    public class ShoppingСart: IEntity
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
