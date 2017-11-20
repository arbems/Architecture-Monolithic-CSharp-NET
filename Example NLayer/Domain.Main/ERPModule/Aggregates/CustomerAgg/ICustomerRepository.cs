namespace Domain.Main.ERPModule.Aggregates.CustomerAgg
{

    using System.Collections.Generic;
    using Domain.Core;

    /// <summary>
    /// Customer repository contract
    /// <see cref="Domain.Core.IRepository{Customer}"/>
    /// </summary>
    public interface ICustomerRepository
        :IRepository<Customer>
    {
        IEnumerable<Customer> GetEnabled(int pageIndex, int pageCount);
    }
}
