using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStoreEntity;

namespace OnlineStoreService
{
    public class CategoryService: ICategoryService
    {
        private IRepository<Category> categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public List<Category> GetAll()
        {
            return categoryRepository.GetAll().ToList();
        }

        public Category GetById(int id)
        {
            if (id == 0)
                return null;
            return categoryRepository.GetById(id);
        }

        public void Insert(Category model)
        {
            if (model == null)
                throw new ArgumentNullException("category");
            categoryRepository.Insert(model);
        }

        public void Update(Category model)
        {
            if (model == null)
                throw new ArgumentNullException("category");
            categoryRepository.Update(model);
        }

        public void Delete(Category model)
        {
            if (model == null)
                throw new ArgumentNullException("category");
            categoryRepository.Delete(model);
        }
    }
}
