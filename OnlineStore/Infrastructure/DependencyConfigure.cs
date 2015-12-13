using System.Web.Mvc;
using Autofac;
using OnlineStore.Infrastructure.Concrete;
using OnlineStoreData;
using OnlineStore.Infrastructure.Abstract;

namespace OnlineStore.Infrastructure
{
    public class DependencyConfigure
    {
        public static void Initialize()
        {
            var builder = new ContainerBuilder();
            DependencyResolver.SetResolver(new Dependency(RegisterServices(builder)));
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {

            builder.RegisterAssemblyTypes(typeof(MvcApplication).Assembly).PropertiesAutowired();
            builder.RegisterGeneric(typeof(RepositoryService<>)).As(typeof(IRepository<>));
            builder.RegisterType(typeof (FormsAuthProvider)).As(typeof (IAuthProvider));
            return builder.Build();
        }
    }
}