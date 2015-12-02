using System.Web.Mvc;
using OnlineStoreEntity;

namespace OnlineStore.Binders
{
    public class CartModelBinder: IModelBinder
    {
        private static string sessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Сart cart = (Сart)controllerContext.HttpContext.Session[sessionKey];

            if (cart == null)
            {
                cart = new Сart();
                controllerContext.HttpContext.Session[sessionKey] = cart;
            }

            return cart;
        }
    }
}