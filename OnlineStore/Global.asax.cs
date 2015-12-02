﻿using System.Data.Entity;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using OnlineStore.Binders;
using OnlineStore.Infrastructure;
using OnlineStoreData.DbInitializer;
using OnlineStoreEntity;

namespace OnlineStore
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            DependencyConfigure.Initialize();
            Database.SetInitializer(new DatabaseInitializer());
            ModelBinders.Binders.Add(typeof(Сart), new CartModelBinder());
        }
    }
}