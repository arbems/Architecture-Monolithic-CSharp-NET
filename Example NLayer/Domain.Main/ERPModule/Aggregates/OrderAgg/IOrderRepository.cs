namespace Domain.Main.ERPModule.Aggregates.OrderAgg
{
    using Domain.Core;

    /// <summary>
    /// The order repository contract
    /// </summary>
    public interface IOrderRepository
        :IRepository<Order>
    {
    }
}
