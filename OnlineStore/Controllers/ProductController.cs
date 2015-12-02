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
        private IRepository<Category> _categoryService;

        public int PageSize = 6;

        public ProductController(IRepository<Product> productService, IRepository<Category> categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
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

        public ActionResult Details(int id)
        {
            var product = _productService.GetById(id);
            
            return View(product);
        }

        //
        // GET: /Category/Create

        public ActionResult Create()
        {
            var categoryList = _categoryService.GetAll().ToList();
            ViewBag.Id = new SelectList(categoryList, "Id", "Name");

            return View();
        }

        //
        // POST: /Category/Create

        [HttpPost]
        public ActionResult Create(Product model)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                ModelState.AddModelError("Name", "Field name is required");
            }

            if (ModelState.IsValid)
            {
                _productService.Insert(model);

                return RedirectToAction("Index");
            }
                
            var categoryList = _categoryService.GetAll().ToList();
            ViewBag.Id = new SelectList(categoryList, "Id", "Name");

            return View(model);
        }

        //
        // GET: /Category/Edit/5

        public ActionResult Edit(int id)
        {
            var product = _productService.GetById(id);

            return View(product);
        }

        //
        // POST: /Category/Edit/5

        [HttpPost]
        public ActionResult Edit(Product model)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(model);

                return RedirectToAction("Index");
            }
                
            return View(model);
        }

        //
        // GET: /Category/Delete/5

        public ActionResult Delete(int id)
        {
            var product = _productService.GetById(id);

            return View(product);

        }

        //
        // POST: /Category/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Product model)
        {
            try
            {
                var product = _productService.GetById(id);

                _productService.Delete(product);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
