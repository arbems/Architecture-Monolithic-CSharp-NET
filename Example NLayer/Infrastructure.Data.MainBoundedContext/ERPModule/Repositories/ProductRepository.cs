

namespace Microsoft.Samples.ExampleNlayer.Infrastructure.Data.MainBoundedContext.ERPModule.Repositories
{
    using Microsoft.Samples.ExampleNlayer.Domain.MainBoundedContext.ERPModule.Aggregates.ProductAgg;
    using Microsoft.Samples.ExampleNlayer.Infrastructure.Data.Seedwork;
    using Microsoft.Samples.ExampleNlayer.Infrastructure.Data.MainBoundedContext.UnitOfWork;

    /// <summary>
    /// Product repository implementation
    /// </summary>
    public class ProductRepository
        :Repository<Product>,IProductRepository
    {
        #region Constructor

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="unitOfWork">Associated unit of work</param>
        public ProductRepository(MainBCUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion
    }
}
