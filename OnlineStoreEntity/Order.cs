using System;

namespace OnlineStoreEntity
{
    public class Order: IEntity
    {
        public int Id { get; set; }
        public int PhoneNumber { get; set; }
        public string CustomerName { get; set; }
        public string DeliveryAddress { get; set; }
        public virtual ShoppingСart ShoppingСart { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
