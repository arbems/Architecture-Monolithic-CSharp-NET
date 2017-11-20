namespace Domain.Main.ERPModule.Aggregates.ProductAgg
{
    using Domain.Core;

    /// <summary>
    /// Base contract for product repository
    /// <see cref="Domain.Core.IRepository{Product}"/>
    /// </summary>
    public interface  IProductRepository
        :IRepository<Product>
    {
    }
}
