using System.Collections.Generic;

namespace OnlineStoreEntity
{
    public class Product: IEntity
    {
        public Product()
        {
            Orders = new List<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public byte[] ProductPhoto { get; set; }
        public bool Discount { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
