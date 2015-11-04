using System.Linq;
using System.Web.Mvc;
using OnlineStoreData;
using OnlineStoreEntity;

namespace OnlineStore.Controllers
{
    public class ProductController : Controller
    {
        private IRepository<Product> _productService;
        private IRepository<Category> _categoryService;

        public ProductController(IRepository<Product> productService, IRepository<Category> categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public ActionResult Index()
        {
            var products = _productService.GetAll().ToList();

            return View(products);
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
