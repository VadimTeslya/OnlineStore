using System;
using System.Collections.Generic;

namespace OnlineStoreEntity
{
    public class Order: IEntity
    {
        public Order()
        {
            Products = new List<Product>();
        }

        public int Id { get; set; }
        public int PhoneNumber { get; set; }
        public string CustomerName { get; set; }
        public string DeliveryAddress { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public virtual ICollection<Product> Products { get; set; } 
    }
}
