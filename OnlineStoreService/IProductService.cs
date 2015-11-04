using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStoreEntity;

namespace OnlineStoreService
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetById(int id);
        void Insert(Product model);
        void Update(Product model);
        void Delete(Product model);
    }
}
