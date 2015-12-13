using System.Web.Mvc;
using OnlineStore.Infrastructure.Abstract;
using OnlineStore.Models;

namespace OnlineStore.Controllers
{
    public class AccountController : Controller
    {
        private IAuthProvider _authProvider;

        public AccountController(IAuthProvider auth)
        {
            _authProvider = auth;
        }

        //
        // GET: /Account/

        public ActionResult Login()
        {
            return View();
        }

        //
        // POST: /Account/

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (_authProvider.Authenticate(model.UserName, model.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                }
            }
            return View();
        }
    }
}
