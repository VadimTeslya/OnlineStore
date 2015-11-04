using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStoreEntity;

namespace OnlineStoreService
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(int id);
        void Insert(Category model);
        void Update(Category model);
        void Delete(Category model);
    }
}
