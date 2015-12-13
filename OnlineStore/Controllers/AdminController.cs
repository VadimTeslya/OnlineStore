using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using OnlineStoreData;
using OnlineStoreEntity;

namespace OnlineStore.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IRepository<Product> _productService;
        private IRepository<Category> _categoryService;

        public AdminController(IRepository<Product> product, IRepository<Category> category)
        {
            _productService = product;
            _categoryService = category;
        }
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View(_productService.GetAll().Include("Category"));
        }

        //
        // GET: /Admin/Edit/5

        public ViewResult Edit(int Id)
        {
            var product = _productService.GetAll()
                .FirstOrDefault(p => p.Id == Id);
            
            return View(product);
        }

        //
        // POST: /Admin/Edit/5

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(product);

                TempData["message"] = string.Format("{0} has been saved", product.Name);

                return RedirectToAction("Index");
            }

            return View(product);
        }

        //
        // GET: /Admin/Create

        public ActionResult Create()
        {
            var categoryList = _categoryService.GetAll().ToList();
            ViewBag.Id = new SelectList(categoryList, "Id", "Name");

            return View();
        }

        //
        // POST: /Admin/Create

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Insert(product);

                return RedirectToAction("Index");
            }

            var categoryList = _categoryService.GetAll().ToList();
            ViewBag.Id = new SelectList(categoryList, "Id", "Name");

            return View(product);
        }

        //
        // POST  /Admin/Delete/5

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            var product = _productService.GetById(Id);
            _productService.Delete(product);
            if (product != null)
            {
                TempData["message"] = string.Format("{0} was deleted", product.Name);
            }
            return RedirectToAction("Index");
        }
    }
}
