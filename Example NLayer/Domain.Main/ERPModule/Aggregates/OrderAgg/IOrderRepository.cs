namespace Nlayer.Samples.NLayerApp.Domain.Main.ERPModule.Aggregates.OrderAgg
{
    using Nlayer.Samples.NLayerApp.Domain.Core;

    /// <summary>
    /// The order repository contract
    /// </summary>
    public interface IOrderRepository
        :IRepository<Order>
    {
    }
}
