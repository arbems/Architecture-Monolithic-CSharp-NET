namespace Nlayer.Samples.NLayerApp.Infrastructure.Data.Main.ERPModule.Repositories
{
    using Nlayer.Samples.NLayerApp.Domain.Main.ERPModule.Aggregates.CountryAgg;
    using Nlayer.Samples.NLayerApp.Infrastructure.Data.Core;    
    using Nlayer.Samples.NLayerApp.Infrastructure.Data.Main.UnitOfWork;
    /// <summary>
    /// The country repository implementation
    /// </summary>
    public class CountryRepository
        :Repository<Country>,ICountryRepository
    {
        #region Constructor

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="unitOfWork">Associated unit of work</param>
        public CountryRepository(MainBCUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion
    }
}
