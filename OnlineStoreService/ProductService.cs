using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStoreEntity;

namespace OnlineStoreService
{
    public class ProductService: IProductService
    {
        private IRepository<Product> productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        public List<Product> GetAll()
        {
            return productRepository.GetAll().ToList();
        }

        public Product GetById(int id)
        {
            if (id == 0)
                return null;
            return productRepository.GetById(id);
        }

        public void Insert(Product model)
        {
            if (model == null)
                throw new ArgumentNullException("product");
            productRepository.Insert(model);
        }

        public void Update(Product model)
        {
            if (model == null)
                throw new ArgumentNullException("product");
            productRepository.Update(model);
        }

        public void Delete(Product model)
        {
            if (model == null)
                throw new ArgumentNullException("product");
            productRepository.Delete(model);
        }
    }
}
