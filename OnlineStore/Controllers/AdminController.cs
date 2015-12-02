using System.Web.Mvc;
using OnlineStoreData;
using OnlineStoreEntity;

namespace OnlineStore.Controllers
{
    public class AdminController : Controller
    {
        private IRepository<Product> _productService;

        public AdminController(IRepository<Product> product)
        {
            _productService = product;
        }
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View(_productService.GetAll());
        }

    }
}
