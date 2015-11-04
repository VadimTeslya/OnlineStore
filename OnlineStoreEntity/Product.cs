namespace OnlineStoreEntity
{
    public class Product: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? Weight { get; set; }
        public byte[] ProductPhoto { get; set; }
        public bool Discount { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
