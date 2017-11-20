namespace DistributedServices.Main
{
    using System;
    using System.Collections.Generic;
    using DistributedServices.Main.InstanceProviders;
    using DistributedServices.Core.ErrorHandlers;
    using Application.Main.ERPModule.Services;
    using Application.Main.DTO;

    [ApplicationErrorHandlerAttribute()] // manage all unhandled exceptions
    [UnityInstanceProviderServiceBehavior()] //create instance and inject dependencies using unity container
    public class ERPModuleService : IERPModuleService
    {

        #region Members

        readonly ICustomerAppService _customerAppService;
        readonly ISalesAppService _salesAppService;

        #endregion

        #region Constructor

        /// <summary>
        /// Create a new instance ERP Module Service
        /// </summary>
        /// <param name="customerAppService">The customer app service dependency</param>
        /// <param name="salesAppService">The sales app service dependency</param>
        public ERPModuleService(ICustomerAppService customerAppService,
                                ISalesAppService salesAppService)
        {
            if (customerAppService == null)
                throw new ArgumentNullException("customerAppService");

            if (salesAppService == null)
                throw new ArgumentNullException("salesAppService");

            _customerAppService = customerAppService;
            _salesAppService = salesAppService;
        }

        #endregion

        #region IERPModuleService Members

        /// <summary>
        /// <see cref="Application.Main.BankingModule.Services.IMainService"/>
        /// </summary>
        /// <param name="customer"><see cref="Application.Main.BankingModule.Services.IMainService"/></param>
        /// <returns><see cref="Application.Main.BankingModule.Services.IMainService"/></returns>
        public CustomerDTO AddNewCustomer(CustomerDTO customer)
        {
            return _customerAppService.AddNewCustomer(customer);
        }

        /// <summary>
        /// <see cref="Application.Main.BankingModule.Services.IMainService"/>
        /// </summary>
        /// <param name="customer"><see cref="Application.Main.BankingModule.Services.IMainService"/></param>
        public void UpdateCustomer(CustomerDTO customer)
        {
            _customerAppService.UpdateCustomer(customer);
        }

        /// <summary>
        /// <see cref="Application.Main.BankingModule.Services.IMainService"/>
        /// </summary>
        /// <param name="customer"><see cref="Application.Main.BankingModule.Services.IMainService"/></param>
        public void RemoveCustomer(Guid customerId)
        {
            _customerAppService.RemoveCustomer(customerId);
        }

        /// <summary>
        /// <see cref="Application.Main.BankingModule.Services.IMainService"/>
        /// </summary>
        /// <param name="pageIndex"><see cref="Application.Main.BankingModule.Services.IMainService"/></param>
        /// <param name="pageCount"><see cref="Application.Main.BankingModule.Services.IMainService"/></param>
        /// <returns><see cref="Application.Main.BankingModule.Services.IMainService"/></returns>
        public List<CustomerListDTO> FindCustomersInPage(int pageIndex, int pageCount)
        {
            return _customerAppService.FindCustomers(pageIndex, pageCount);
        }

        /// <summary>
        /// <see cref="Application.Main.BankingModule.Services.IMainService"/>
        /// </summary>
        /// <param name="filter"><see cref="Application.Main.BankingModule.Services.IMainService"/></param>
        /// <returns><see cref="Application.Main.BankingModule.Services.IMainService"/></returns>
        public List<CustomerListDTO> FindCustomersByFilter(string filter)
        {
            return _customerAppService.FindCustomers(filter);
        }

        /// <summary>
        /// <see cref="Application.Main.BankingModule.Services.IMainService"/>
        /// </summary>
        /// <param name="customerId"><see cref="Application.Main.BankingModule.Services.IMainService"/></param>
        /// <returns><see cref="Application.Main.BankingModule.Services.IMainService"/></returns>
        public CustomerDTO FindCustomer(Guid customerId)
        {
            return _customerAppService.FindCustomer(customerId);
        }

        /// <summary>
        /// <see cref="Application.Main.BankingModule.Services.IMainService"/>
        /// </summary>
        /// <param name="pageIndex"><see cref="Application.Main.BankingModule.Services.IMainService"/></param>
        /// <param name="pageCount"><see cref="Application.Main.BankingModule.Services.IMainService"/></param>
        /// <returns><see cref="Application.Main.BankingModule.Services.IMainService"/></returns>
        public List<CountryDTO> FindCountriesInPage(int pageIndex, int pageCount)
        {
            return _customerAppService.FindCountries(pageIndex, pageCount);
        }

        /// <summary>
        /// <see cref="Application.Main.BankingModule.Services.IMainService"/>
        /// </summary>
        /// <param name="filter"><see cref="Application.Main.BankingModule.Services.IMainService"/></param>
        /// <returns><see cref="Application.Main.BankingModule.Services.IMainService"/></returns>
        public List<CountryDTO> FindCountriesByFilter(string filter)
        {
            return _customerAppService.FindCountries(filter);
        }

        /// <summary>
        /// <see cref="Application.Main.BankingModule.Services.IMainService"/>
        /// </summary>
        /// <param name="pageIndex"><see cref="Application.Main.BankingModule.Services.IMainService"/></param>
        /// <param name="pageCount"><see cref="Application.Main.BankingModule.Services.IMainService"/></param>
        /// <returns><see cref="Application.Main.BankingModule.Services.IMainService"/></returns>
        public List<OrderListDTO> FindOrdersInPage(int pageIndex, int pageCount)
        {
            return _salesAppService.FindOrders(pageIndex, pageCount);
        }

        /// <summary>
        /// <see cref="Application.Main.BankingModule.Services.IMainService"/>
        /// </summary>
        /// <param name="from"><see cref="Application.Main.BankingModule.Services.IMainService"/></param>
        /// <param name="to"><see cref="Application.Main.BankingModule.Services.IMainService"/></param>
        /// <returns><see cref="Application.Main.BankingModule.Services.IMainService"/></returns>
        public List<OrderListDTO> FindOrdersByFilter(DateTime from, DateTime to)
        {
            return _salesAppService.FindOrders(from, to);
        }

        /// <summary>
        /// <see cref="Application.Main.BankingModule.Services.IMainService"/>
        /// </summary>
        /// <param name="customerId"><see cref="Application.Main.BankingModule.Services.IMainService"/></param>
        /// <returns><see cref="Application.Main.BankingModule.Services.IMainService"/></returns>
        public List<OrderListDTO> FindOrdersByCustomer(Guid customerId)
        {
            return _salesAppService.FindOrders(customerId);
        }

        /// <summary>
        /// <see cref="Application.Main.BankingModule.Services.IMainService"/>
        /// </summary>
        /// <param name="order"><see cref="Application.Main.BankingModule.Services.IMainService"/></param>
        /// <returns><see cref="Application.Main.BankingModule.Services.IMainService"/></returns>
        public OrderDTO AddNewOrder(OrderDTO order)
        {
            return _salesAppService.AddNewOrder(order);
        }

        /// <summary>
        /// <see cref="Application.Main.BankingModule.Services.IMainService"/>
        /// </summary>
        /// <param name="software"><see cref="Application.Main.BankingModule.Services.IMainService"/></param>
        /// <returns><see cref="Application.Main.BankingModule.Services.IMainService"/></returns>
        public SoftwareDTO AddNewSoftware(SoftwareDTO software)
        {
            return _salesAppService.AddNewSoftware(software);
        }

        /// <summary>
        /// <see cref="Application.Main.BankingModule.Services.IMainService"/>
        /// </summary>
        /// <param name="book"><see cref="Application.Main.BankingModule.Services.IMainService"/></param>
        /// <returns><see cref="Application.Main.BankingModule.Services.IMainService"/></returns>
        public BookDTO AddNewBook(BookDTO book)
        {
            return _salesAppService.AddNewBook(book);
        }

        /// <summary>
        /// <see cref="Application.Main.BankingModule.Services.IMainService"/>
        /// </summary>
        /// <param name="pageIndex"><see cref="Application.Main.BankingModule.Services.IMainService"/></param>
        /// <param name="pageCount"><see cref="Application.Main.BankingModule.Services.IMainService"/></param>
        /// <returns><see cref="Application.Main.BankingModule.Services.IMainService"/></returns>
        public List<ProductDTO> FindProductsInPage(int pageIndex, int pageCount)
        {
            return _salesAppService.FindProducts(pageIndex, pageCount);
        }

        /// <summary>
        /// <see cref="Application.Main.BankingModule.Services.IMainService"/>
        /// </summary>
        /// <param name="filter"><see cref="Application.Main.BankingModule.Services.IMainService"/></param>
        /// <returns><see cref="Application.Main.BankingModule.Services.IMainService"/></returns>
        public List<ProductDTO> FindProductsByFilter(string filter)
        {
            return _salesAppService.FindProducts(filter);
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// <see cref="M:System.IDisposable.Dispose"/>
        /// </summary>
        public void Dispose()
        {
            //dispose all resources
            _salesAppService.Dispose();
            _customerAppService.Dispose();
        }
        #endregion
    }
}
