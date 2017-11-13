using Nlayer.Samples.NLayerApp.Application.Main.ERPModule.Services;
using Nlayer.Samples.NLayerApp.Domain.Main.ERPModule.Aggregates.CountryAgg;
using Nlayer.Samples.NLayerApp.Domain.Main.ERPModule.Aggregates.CustomerAgg;
using Nlayer.Samples.NLayerApp.Infrastructure.Crosscutting.Adapter;
using Nlayer.Samples.NLayerApp.Infrastructure.Crosscutting.NetFramework.Adapter;
using Nlayer.Samples.NLayerApp.Infrastructure.Data.Main.ERPModule.Repositories;
using System;
using System.Web;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace WebAppMVC
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            container.RegisterType<ICustomerAppService, CustomerAppService>();
            container.RegisterType<ICountryRepository, CountryRepository>();
            container.RegisterType<ICustomerRepository, CustomerRepository>();
            container.RegisterType<HttpContextBase>(new InjectionFactory(c =>
            {
                return new HttpContextWrapper(HttpContext.Current);
            }));

            //-> Adapters
            //container.RegisterType<ITypeAdapterFactory, AutomapperTypeAdapterFactory>(new ContainerControlledLifetimeManager());
            //var typeAdapterFactory = container.Resolve<ITypeAdapterFactory>();
            //TypeAdapterFactory.SetCurrent(typeAdapterFactory);
        }
    }
}