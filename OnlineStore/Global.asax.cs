using System.Data.Entity;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using OnlineStore.Binders;
using OnlineStore.Infrastructure;
using OnlineStoreData;
using OnlineStoreEntity;

namespace OnlineStore
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataContext>());
            DependencyConfigure.Initialize();
            ModelBinders.Binders.Add(typeof(Сart), new CartModelBinder());
        }
    }
}