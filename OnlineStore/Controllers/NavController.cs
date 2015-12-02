using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using OnlineStoreData;
using OnlineStoreEntity;

namespace OnlineStore.Controllers
{
    public class NavController : Controller
    {
        private IRepository<Category> _categoryService;

        public NavController(IRepository<Category> category)
        {
            _categoryService = category;
        }
        //
        // GET: /Nav/

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            var categories = _categoryService.GetAll()
                .Select(c => c.Name)
                .Distinct()
                .OrderBy(c => c);

            return PartialView(categories);
        }
    }
}
