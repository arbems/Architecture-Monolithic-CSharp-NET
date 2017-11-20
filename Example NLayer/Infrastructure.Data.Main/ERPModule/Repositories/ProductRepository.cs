

namespace Infrastructure.Data.Main.ERPModule.Repositories
{
    using Domain.Main.ERPModule.Aggregates.ProductAgg;
    using Infrastructure.Data.Core;
    using Infrastructure.Data.Main.UnitOfWork;

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
