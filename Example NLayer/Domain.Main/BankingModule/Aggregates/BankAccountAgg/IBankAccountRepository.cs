namespace Domain.Main.BankingModule.Aggregates.BankAccountAgg
{
    using Domain.Core;

    /// <summary>
    /// Base contract for bank account repository
    /// <see cref="Domain.Core.IRepository{BankAccount}"/>
    /// </summary>
    public interface IBankAccountRepository
        :IRepository<BankAccount>
    {
    }
}
