namespace Nlayer.Samples.NLayerApp.Domain.Main.ERPModule.Aggregates.ProductAgg
{
    using Nlayer.Samples.NLayerApp.Domain.Core;

    /// <summary>
    /// Base contract for product repository
    /// <see cref="Nlayer.Samples.NLayerApp.Domain.Core.IRepository{Product}"/>
    /// </summary>
    public interface  IProductRepository
        :IRepository<Product>
    {
    }
}
