namespace Infrastructure.Data.Main.ERPModule.Repositories
{
    using System.Linq;
    using System.Collections.Generic;
    using Domain.Main.ERPModule.Aggregates.CountryAgg;
    using Infrastructure.Data.Core;
    using Infrastructure.Data.Main.UnitOfWork;
    using Infrastructure.Crosscutting.Caching;

    /// <summary>
    /// The country repository implementation
    /// </summary>
    public class CountryRepository
        :Repository<Country>,ICountryRepository
    {
        private readonly ICacheManager cacheManager;

        #region Constructor

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="unitOfWork">Associated unit of work</param>
        public CountryRepository(MainBCUnitOfWork unitOfWork, ICacheManager _cacheManager)
            : base(unitOfWork)
        {
            this.cacheManager = _cacheManager;
        }

        public override IEnumerable<Country> GetAll()
        {
            var currentUnitOfWork = this.UnitOfWork as MainBCUnitOfWork;

            var set = currentUnitOfWork.CreateSet<Country>();

            string key = "Countries";
            var categories = cacheManager.Get(key, () =>
            {
                return set;
            });

            return base.GetAll();
        }

        #endregion
    }
}
