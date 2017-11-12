namespace Nlayer.Samples.ExampleNlayer.Domain.MainBoundedContext.BankingModule.Services
{
    using Nlayer.Samples.ExampleNlayer.Domain.MainBoundedContext.BankingModule.Aggregates.BankAccountAgg;
    using Nlayer.Samples.ExampleNlayer.Domain.MainBoundedContext.Resources;
    using System;

    /// <summary>
    /// Bank transfer service implementation. 
    /// <see cref="Nlayer.Samples.ExampleNlayer.Domain.MainBoundedContext.Aggregates.BankAccounts.IBankTransferService"/>
    /// </summary>
    public class BankTransferService : IBankTransferService
    {
        /// <summary>
        /// <see cref="Nlayer.Samples.ExampleNlayer.Domain.MainBoundedContext.BankingModule.Services.IBankTransferService"/>
        /// </summary>
        /// <param name="amount"> <see cref="Nlayer.Samples.ExampleNlayer.Domain.MainBoundedContext.BankingModule.Services.IBankTransferService"/></param>
        /// <param name="originAccount"> <see cref="Nlayer.Samples.ExampleNlayer.Domain.MainBoundedContext.BankingModule.Services.IBankTransferService"/></param>
        /// <param name="destinationAccount"> <see cref="Nlayer.Samples.ExampleNlayer.Domain.MainBoundedContext.BankingModule.Services.IBankTransferService"/></param>
        public void PerformTransfer(decimal amount, BankAccount originAccount, BankAccount destinationAccount)
        {
            if (originAccount != null && destinationAccount != null)
            {
                if (originAccount.BankAccountNumber == destinationAccount.BankAccountNumber) // if transfer in same bank account
                    throw new InvalidOperationException(Messages.exception_CannotTransferMoneyWhenFromIsTheSameAsTo);

                // Check if customer has required credit and if the BankAccount is not locked
                if (originAccount.CanBeWithdrawed(amount))
                {
                    //Domain Logic
                    //Process: Perform transfer operations to in-memory Domain-Model objects        
                    // 1.- Charge money to origin acc
                    // 2.- Credit money to destination acc

                    //Charge money
                    originAccount.WithdrawMoney(amount, string.Format(Messages.messages_TransactionFromMessage, destinationAccount.Id));

                    //Credit money
                    destinationAccount.DepositMoney(amount, string.Format(Messages.messages_TransactionToMessage, originAccount.Id));
                }
                else
                    throw new InvalidOperationException(Messages.exception_BankAccountCannotWithdraw);
            }
        }
    }
}
