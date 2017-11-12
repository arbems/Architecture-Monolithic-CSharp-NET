namespace Nlayer.Samples.ExampleNlayer.Domain.MainBoundedContext.ERPModule.Aggregates.ProductAgg
{
    using Nlayer.Samples.ExampleNlayer.Domain.Seedwork;

    /// <summary>
    /// Base contract for product repository
    /// <see cref="Nlayer.Samples.ExampleNlayer.Domain.Seedwork.IRepository{Product}"/>
    /// </summary>
    public interface  IProductRepository
        :IRepository<Product>
    {
    }
}
