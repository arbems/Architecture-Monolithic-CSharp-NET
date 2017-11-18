//===================================================================================
// Microsoft Developer & Platform Evangelism
//=================================================================================== 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//===================================================================================
// Copyright (c) Microsoft Corporation.  All Rights Reserved.
// This code is released under the terms of the MS-LPL license, 
// http://microsoftnlayerapp.codeplex.com/license
//===================================================================================
			
namespace Microsoft.Samples.NLayerApp.DistributedServices.MainBoundedContext.InstanceProviders
{
    using Microsoft.Practices.Unity;
    using Nlayer.Samples.NLayerApp.Application.Main.BankingModule.Services;
    using Nlayer.Samples.NLayerApp.Application.Main.ERPModule.Services;
    using Nlayer.Samples.NLayerApp.DistributedServices.Main;
    using Nlayer.Samples.NLayerApp.Domain.Main.BankingModule.Aggregates.BankAccountAgg;
    using Nlayer.Samples.NLayerApp.Domain.Main.BankingModule.Services;
    using Nlayer.Samples.NLayerApp.Domain.Main.ERPModule.Aggregates.CountryAgg;
    using Nlayer.Samples.NLayerApp.Domain.Main.ERPModule.Aggregates.CustomerAgg;
    using Nlayer.Samples.NLayerApp.Domain.Main.ERPModule.Aggregates.OrderAgg;
    using Nlayer.Samples.NLayerApp.Domain.Main.ERPModule.Aggregates.ProductAgg;
    using Nlayer.Samples.NLayerApp.Infrastructure.Crosscutting.Adapter;
    using Nlayer.Samples.NLayerApp.Infrastructure.Crosscutting.Logging;
    using Nlayer.Samples.NLayerApp.Infrastructure.Crosscutting.NetFramework.Adapter;
    using Nlayer.Samples.NLayerApp.Infrastructure.Crosscutting.NetFramework.Logging;
    using Nlayer.Samples.NLayerApp.Infrastructure.Crosscutting.NetFramework.Validator;
    using Nlayer.Samples.NLayerApp.Infrastructure.Crosscutting.Validator;
    using Nlayer.Samples.NLayerApp.Infrastructure.Data.Main.BankingModule.Repositories;
    using Nlayer.Samples.NLayerApp.Infrastructure.Data.Main.ERPModule.Repositories;

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