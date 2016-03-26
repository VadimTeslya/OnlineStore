using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using OnlineStore.Models;
using OnlineStoreData;
using OnlineStoreEntity;

namespace OnlineStore.Controllers
{
    public class ProductController : Controller
    {
        private IRepository<Product> _productService;
        private int PageSize = 12;

        public ProductController(IRepository<Product> productService)
        {
            _productService = productService;
        }

        public ActionResult Index(string category, int page = 1)
        {
            var model = new ProductListViewModel
            {
                Products = _productService.GetAll()
                    .Where(p => category == null || p.Category.Name == category)
                    .Include("Category")
                    .OrderBy(p => p.Id)
                    .Skip((page - 1)*PageSize)
                    .Take(PageSize)
                    .ToList(),
                PageInfo = new PageInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                        _productService.GetAll().Count() :
                        _productService.GetAll().Count(p => p.Category.Name == category)
                },
                CurrentCategory = category
            };
            
            return View(model);
        }

        public FileContentResult GetPhoto(int id)
        {
            var product = _productService.GetById(id);
            if (product != null)
            {
                return File(product.ProductPhoto, product.PhotoMimeType);
            }
            return null;
        }
    }
}
