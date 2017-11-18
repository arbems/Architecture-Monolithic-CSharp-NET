namespace Nlayer.Samples.NLayerApp.Domain.Main.BankingModule.Aggregates.BankAccountAgg
{
    using Nlayer.Samples.NLayerApp.Domain.Core;

    /// <summary>
    /// Base contract for bank account repository
    /// <see cref="Nlayer.Samples.NLayerApp.Domain.Core.IRepository{BankAccount}"/>
    /// </summary>
    public interface IBankAccountRepository
        :IRepository<BankAccount>
    {
    }
}
