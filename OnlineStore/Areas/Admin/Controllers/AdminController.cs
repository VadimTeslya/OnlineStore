using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using OnlineStoreData;
using OnlineStoreEntity;
using PagedList;
using PagedList.Mvc;

namespace OnlineStore.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private IRepository<Product> _productService;
        private IRepository<Category> _categoryService;
        
        public AdminController(IRepository<Product> product, IRepository<Category> category)
        {
            _productService = product;
            _categoryService = category;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Product(int? page, string searchString)
        {
            int pageSize = 8;
            int pageNumber = (page ?? 1);

            if(!string.IsNullOrEmpty(searchString))
            {
                return View(_productService.GetAll().
                    Include("Category").
                    Where(p => p.Name.Contains(searchString)).
                    ToList().
                    ToPagedList(pageNumber, pageSize));
            }

            return View(_productService.GetAll().Include("Category").ToList().ToPagedList(pageNumber, pageSize));
        }

        public ViewResult EditProduct(int Id)
        {
            return View(_productService.GetAll()
                .FirstOrDefault(p => p.Id == Id));
        }

        [HttpPost]
        public ActionResult EditProduct(Product product, HttpPostedFileBase photo)
        {
            if (ModelState.IsValid)
            {
                if (photo != null)
                {
                    product.PhotoMimeType = photo.ContentType;
                    product.ProductPhoto = new byte[photo.ContentLength];
                    photo.InputStream.Read(product.ProductPhoto, 0, photo.ContentLength);
                }
                
                _productService.Update(product);
                TempData["message"] = string.Format("{0} has been saved", product.Name);
                return RedirectToAction("Index");
            }

            return View(product);
        }

        public ActionResult CreateProduct()
        {
            ViewBag.Id = new SelectList(_categoryService.GetAll().ToList(), "Id", "Name");
            return PartialView("_CreateProduct");
        }

        [HttpPost]
        public ActionResult CreateProduct(Product product, HttpPostedFileBase photo)
        {
            if (ModelState.IsValid)
            {
                if (photo != null)
                {
                    product.PhotoMimeType = photo.ContentType;
                    product.ProductPhoto = new byte[photo.ContentLength];
                    photo.InputStream.Read(product.ProductPhoto, 0, photo.ContentLength);
                }

                _productService.Insert(product);
                TempData["message"] = string.Format("{0} has been created", product.Name);

                return Json( new { success = true });
            }
            
            ViewBag.Id = new SelectList(_categoryService.GetAll().ToList(), "Id", "Name");

            return PartialView("_CreateProduct", product);
        }

        [HttpPost]
        public ActionResult DeleteProduct(int Id)
        {
            var product = _productService.GetById(Id);
            _productService.Delete(product);
            if (product != null)
            {
                TempData["message"] = string.Format("{0} was deleted", product.Name);
            }
            return RedirectToAction("Product");
        }

        public ActionResult Category()
        {
            return View(_categoryService.GetAll().Include("Products"));
        }

        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            if (_categoryService.GetAll().Count(c => c.Name == category.Name) > 0)
                return RedirectToAction("Create",
                        new RouteValueDictionary {  
                            { "id", null},  
                            { "createError", true } });

            if (ModelState.IsValid)
            {
                _categoryService.Insert(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public ActionResult EditCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteCategory()
        {
            return View();
        }
    }
}
