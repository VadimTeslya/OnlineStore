using System.Web.Mvc;
using Autofac;
using OnlineStoreData;
using OnlineStoreEntity;

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
            return builder.Build();
        }
    }
}