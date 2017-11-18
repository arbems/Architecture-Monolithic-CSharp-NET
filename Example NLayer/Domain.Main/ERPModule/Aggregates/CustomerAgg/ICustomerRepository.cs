namespace Nlayer.Samples.NLayerApp.Domain.Main.ERPModule.Aggregates.CustomerAgg
{

    using System.Collections.Generic;
    using Nlayer.Samples.NLayerApp.Domain.Core;

    /// <summary>
    /// Customer repository contract
    /// <see cref="Nlayer.Samples.NLayerApp.Domain.Core.IRepository{Customer}"/>
    /// </summary>
    public interface ICustomerRepository
        :IRepository<Customer>
    {
        IEnumerable<Customer> GetEnabled(int pageIndex, int pageCount);
    }
}
