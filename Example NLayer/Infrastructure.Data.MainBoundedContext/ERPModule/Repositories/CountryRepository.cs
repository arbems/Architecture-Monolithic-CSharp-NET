namespace Microsoft.Samples.ExampleNlayer.Infrastructure.Data.MainBoundedContext.ERPModule.Repositories
{
    using Microsoft.Samples.ExampleNlayer.Domain.MainBoundedContext.ERPModule.Aggregates.CountryAgg;
    using Microsoft.Samples.ExampleNlayer.Infrastructure.Data.Seedwork;    
    using Microsoft.Samples.ExampleNlayer.Infrastructure.Data.MainBoundedContext.UnitOfWork;
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
