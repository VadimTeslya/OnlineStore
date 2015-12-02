using System;
using System.Linq;
using System.Web.Mvc;
using OnlineStore.Models;
using OnlineStoreData;
using OnlineStoreEntity;

namespace OnlineStore.Controllers
{
    public class CartController : Controller
    {
        private IRepository<Product> _productService;
        private IRepository<Order> _orderService; 

        public CartController(IRepository<Product> product, IRepository<Order> order)
        {
            _productService = product;
            _orderService = order;
        }

        public ViewResult Index(Сart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(Сart cart, int Id, string returnUrl)
        {
            var product = _productService.GetAll()
                .FirstOrDefault(p => p.Id == Id);

            if (product != null)
            {
                cart.AddItem(product, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Сart cart, int id, string returnUrl)
        {
            var product = _productService.GetAll().FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                cart.RemoveLine(product);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(Сart cart)
        {
            return PartialView(cart);
        }

        public ViewResult Checkout()
        {
            return View(new Order());
        }

        [HttpPost]
        public ViewResult Checkout(Сart cart, Order order)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                order.OrderDate = DateTime.UtcNow;
                _orderService.Insert(order);
            }
            return View();
        }
    }
}
