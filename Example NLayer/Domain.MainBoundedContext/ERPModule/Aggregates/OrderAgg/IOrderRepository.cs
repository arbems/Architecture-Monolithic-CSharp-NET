namespace Nlayer.Samples.ExampleNlayer.Domain.MainBoundedContext.ERPModule.Aggregates.OrderAgg
{
    using Nlayer.Samples.ExampleNlayer.Domain.Seedwork;

    /// <summary>
    /// The order repository contract
    /// </summary>
    public interface IOrderRepository
        :IRepository<Order>
    {
    }
}
