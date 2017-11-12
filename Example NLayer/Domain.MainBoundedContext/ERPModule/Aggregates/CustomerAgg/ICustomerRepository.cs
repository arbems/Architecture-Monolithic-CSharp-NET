namespace Nlayer.Samples.ExampleNlayer.Domain.MainBoundedContext.ERPModule.Aggregates.CustomerAgg
{

    using System.Collections.Generic;
    using Nlayer.Samples.ExampleNlayer.Domain.Seedwork;

    /// <summary>
    /// Customer repository contract
    /// <see cref="Nlayer.Samples.ExampleNlayer.Domain.Seedwork.IRepository{Customer}"/>
    /// </summary>
    public interface ICustomerRepository
        :IRepository<Customer>
    {
        IEnumerable<Customer> GetEnabled(int pageIndex, int pageCount);
    }
}
