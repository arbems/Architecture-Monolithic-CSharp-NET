
namespace Infrastructure.Data.Main.BankingModule.Repositories
{
    using System.Linq;
    using System.Collections.Generic;
    using System.Data.Entity;

    using Domain.Main.BankingModule.Aggregates.BankAccountAgg;
    using Infrastructure.Data.Core;
    using Infrastructure.Data.Main.UnitOfWork;

    /// <summary>
    /// The bank account repository implementation
    /// </summary>
    public class BankAccountRepository
        :Repository<BankAccount>,IBankAccountRepository
    {
        #region Constructor

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="unitOfWork">Associated unit of work</param>
        public BankAccountRepository(MainBCUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Get all bank accounts and the customer information
        /// </summary>
        /// <returns>Enumerable collection of bank accounts</returns>
        public override IEnumerable<BankAccount> GetAll()
        {
            var currentUnitOfWork = this.UnitOfWork as MainBCUnitOfWork;

            var set = currentUnitOfWork.CreateSet<BankAccount>();

            return set.Include(ba => ba.Customer)
                      .AsEnumerable();
            
        }
        #endregion
    }
}
