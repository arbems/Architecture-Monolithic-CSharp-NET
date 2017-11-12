namespace Nlayer.Samples.ExampleNlayer.Domain.MainBoundedContext.BankingModule.Aggregates.BankAccountAgg
{
    using Nlayer.Samples.ExampleNlayer.Domain.Seedwork;

    /// <summary>
    /// Base contract for bank account repository
    /// <see cref="Nlayer.Samples.ExampleNlayer.Domain.Seedwork.IRepository{BankAccount}"/>
    /// </summary>
    public interface IBankAccountRepository
        :IRepository<BankAccount>
    {
    }
}
