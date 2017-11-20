namespace DistributedServices.Main.InstanceProviders
{
    using Microsoft.Practices.Unity;
    using Application.Main.BankingModule.Services;
    using Application.Main.ERPModule.Services;
    using DistributedServices.Main;
    using Domain.Main.BankingModule.Aggregates.BankAccountAgg;
    using Domain.Main.BankingModule.Services;
    using Domain.Main.ERPModule.Aggregates.CountryAgg;
    using Domain.Main.ERPModule.Aggregates.CustomerAgg;
    using Domain.Main.ERPModule.Aggregates.OrderAgg;
    using Domain.Main.ERPModule.Aggregates.ProductAgg;
    using Infrastructure.Crosscutting.Adapter;
    using Infrastructure.Crosscutting.Logging;
    using Infrastructure.Crosscutting.NetFramework.Adapter;
    using Infrastructure.Crosscutting.NetFramework.Logging;
    using Infrastructure.Crosscutting.NetFramework.Validator;
    using Infrastructure.Crosscutting.Validator;
    using Infrastructure.Data.Main.BankingModule.Repositories;
    using Infrastructure.Data.Main.ERPModule.Repositories;

    /// <summary>
    /// DI container accessor
    /// </summary>
    public static class Container
    {
        #region Properties

        static  IUnityContainer _currentContainer;

        /// <summary>
        /// Get the current configured container
        /// </summary>
        /// <returns>Configured container</returns>
        public static IUnityContainer Current
        {
            get
            {
                return _currentContainer;
            }
        }

        #endregion

        #region Constructor
        
        static Container()
        {
            ConfigureContainer();

            ConfigureFactories();
        }

        #endregion

        #region Methods

        static void ConfigureContainer()
        {
            /*
             * Add here the code configuration or the call to configure the container 
             * using the application configuration file
             */

            _currentContainer = new UnityContainer();
            
            
            //-> Unit of Work and repositories
            //ERROR _currentContainer.RegisterType(typeof(MainBCUnitOfWork), new PerResolveLifetimeManager());
            

            _currentContainer.RegisterType<IBankAccountRepository, BankAccountRepository>();
            _currentContainer.RegisterType<ICountryRepository, CountryRepository>();
            _currentContainer.RegisterType<ICustomerRepository, CustomerRepository>();
            _currentContainer.RegisterType<IOrderRepository,OrderRepository>();
            _currentContainer.RegisterType<IProductRepository, ProductRepository>();

            //-> Adapters
            _currentContainer.RegisterType<ITypeAdapterFactory, AutomapperTypeAdapterFactory>(new ContainerControlledLifetimeManager());

            //-> Domain Services
            _currentContainer.RegisterType<IBankTransferService, BankTransferService>();

            //-> Application services
            _currentContainer.RegisterType<ISalesAppService, SalesAppService>();
            _currentContainer.RegisterType<ICustomerAppService, CustomerAppService>();
            _currentContainer.RegisterType<IBankAppService, BankAppService>();

            //-> Distributed Services
            _currentContainer.RegisterType<IBankingModuleService, BankingModuleService>();
            _currentContainer.RegisterType<IERPModuleService, ERPModuleService>();
        }


        static void ConfigureFactories()
        {
            LoggerFactory.SetCurrent(new TraceSourceLogFactory());
            EntityValidatorFactory.SetCurrent(new DataAnnotationsEntityValidatorFactory());

            var typeAdapterFactory = _currentContainer.Resolve<ITypeAdapterFactory>();
            TypeAdapterFactory.SetCurrent(typeAdapterFactory);
        }

        #endregion
    }
}