[assembly: WebActivator.PostApplicationStartMethod(typeof(Marina.Web.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace Marina.Web.App_Start
{
    using System.Web.Http;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    using AutoMapper;
    using Data.Infrastructure;
    using Data.Repositories;
    using Service;

    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
       
            container.Verify();
            
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
     
        private static void InitializeContainer(Container container)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfiles(new[] { "Marina.Web" });
            });
            container.Register(() => config.CreateMapper(), Lifestyle.Singleton);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<IDbFactory, DbFactory>(Lifestyle.Scoped);
            container.Register<IPersonRepository, PersonRepository>(Lifestyle.Scoped);
            container.Register<IPersonService, PersonService>(Lifestyle.Scoped);
        }
    }
}