using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace OnlineStoreEntity
{
    public class Product: IEntity
    {
        public Product()
        {
            Orders = new List<Order>();
        }

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Field Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Field price is required")]
        public decimal Price { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public byte[] ProductPhoto { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string PhotoMimeType { get; set; }

        public bool Discount { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
