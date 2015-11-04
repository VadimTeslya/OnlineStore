using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using OnlineStoreData;
using OnlineStoreEntity;

namespace OnlineStore.Controllers
{
    public class CategoryController : Controller
    {
        private IRepository<Category> _categoryService;

        public CategoryController(IRepository<Category> categoryService)
        {
            _categoryService = categoryService;
        }

        //
        // GET: /Category/

        public ActionResult Index()
        {
            var a = 2;
            var cagetoryList = _categoryService.GetAll().ToList();

            return View(cagetoryList);
        }

        //
        // GET: /Category/Details/5

        public ActionResult Details(int id)
        {
            var category = _categoryService.GetById(id);

            return View(category);
        }

        //
        // GET: /Category/Create

        public ActionResult Create(bool? createError)
        {
            if (createError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Error.";
            }

            return View();
        }

        //
        // POST: /Category/Create

        [HttpPost]
        public ActionResult Create(Category model)
        {
            if (_categoryService.GetAll().Count(c => c.Name == model.Name) > 0)
                return RedirectToAction("Create",
                        new RouteValueDictionary {  
                            { "id", null},  
                            { "createError", true } });

            if (ModelState.IsValid)
            {
                _categoryService.Insert(model);

                return RedirectToAction("Index");
            }
                    
            return View(model);
        }

        //
        // GET: /Category/Edit/5

        public ActionResult Edit(int id)
        {
            var category = _categoryService.GetById(id);

            return View(category);
        }

        //
        // POST: /Category/Edit/5

        [HttpPost]
        public ActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Update(model);

                return RedirectToAction("Index");
            }
               
            return View(model);
         }

        //
        // GET: /Category/Delete/5

        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to delete. Try again, and if the problem persists see your system administrator.";
            }
            
            return View(_categoryService.GetById(id));
        }

        //
        // POST: /Category/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Category model)
        {
            try
            {
                    var category = _categoryService.GetById(id);
                    _categoryService.Delete(category);
            }
            catch (DataException)
            {

                return RedirectToAction("Delete",
                    new RouteValueDictionary {  
                        { "id", id },  
                        { "saveChangesError", true } }); 
            }

            return RedirectToAction("Index");
        }
    }
}
