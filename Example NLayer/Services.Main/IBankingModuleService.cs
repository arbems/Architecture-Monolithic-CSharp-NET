namespace DistributedServices.Main
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;
    using Application.Main.DTO;
    using DistributedServices.Core.ErrorHandlers;

    /// <summary>
    /// WCF SERVICE FACADE for Banking Module
    /// </summary>
    [ServiceContract]
    public interface IBankingModuleService : IDisposable
    {
        [OperationContract()]
        [FaultContract(typeof(ApplicationServiceError))]
        BankAccountDTO AddNewBankAccount(BankAccountDTO bankAccount);

        [OperationContract()]
        [FaultContract(typeof(ApplicationServiceError))]
        bool LockBankAccount(Guid bankAccountId);

        [OperationContract()]
        [FaultContract(typeof(ApplicationServiceError))]
        List<BankAccountDTO> FindBankAccounts();

        [OperationContract()]
        [FaultContract(typeof(ApplicationServiceError))]
        List<BankActivityDTO> FindBankAccountActivities(Guid bankAccountId);

        [OperationContract()]
        [FaultContract(typeof(ApplicationServiceError))]
        void PerformTransfer(BankAccountDTO from, BankAccountDTO to, decimal amount);
    }
}
