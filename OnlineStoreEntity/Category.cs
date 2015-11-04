using System.Collections.Generic;

namespace OnlineStoreEntity
{
    public class Category: IEntity
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
