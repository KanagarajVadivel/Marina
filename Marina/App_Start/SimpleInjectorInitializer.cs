[assembly: WebActivator.PostApplicationStartMethod(typeof(Marina.Web.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace Marina.Web.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;

    using SimpleInjector;
    using SimpleInjector.Extensions;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    using Data.Infrastructure;
    using Data.Repositories;
    using Service;
    using AutoMapper;
    using Data;
    using Model;

    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
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