namespace DistributedServices.Main
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;

    using Application.Main.BankingModule.Services;
    using DistributedServices.Core.ErrorHandlers;
    using Application.Main.DTO;
    using DistributedServices.Main.InstanceProviders;

    [ApplicationErrorHandlerAttribute()] // manage all unhandled exceptions
    [UnityInstanceProviderServiceBehavior()] //create instance and inject dependencies using unity container
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class BankingModuleService : IBankingModuleService
    {
        #region Members

        readonly IBankAppService _bankAppService;

        #endregion

        #region Constructor

        /// <summary>
        /// Create a new instance of banking module service
        /// </summary>
        /// <param name="bankAppService">The bank application service dependency</param>
        public BankingModuleService(IBankAppService bankAppService)
        {
            _bankAppService = bankAppService ?? throw new ArgumentNullException("bankAppService");
        }
        #endregion

        #region IBaningModuleService Members

        /// <summary>
        /// <see cref="Application.Main.BankingModule.Services.IMainService"/>
        /// </summary>
        /// <param name="newBankAccount"><see cref="Application.Main.BankingModule.Services.IMainService"/></param>
        /// <returns><see cref="Application.Main.BankingModule.Services.IMainService"/></returns>
        public BankAccountDTO AddNewBankAccount(BankAccountDTO newBankAccount)
        {
            return _bankAppService.AddBankAccount(newBankAccount);
        }

        /// <summary>
        /// <see cref="Application.Main.BankingModule.Services.IMainService"/>
        /// </summary>
        /// <param name="bankAccountId"><see cref="Application.Main.BankingModule.Services.IMainService"/></param>
        /// <returns><see cref="Application.Main.BankingModule.Services.IMainService"/></returns>
        public bool LockBankAccount(Guid bankAccountId)
        {
            return _bankAppService.LockBankAccount(bankAccountId);
        }

        /// <summary>
        /// <see cref="Application.Main.BankingModule.Services.IMainService"/>
        /// </summary>
        /// <returns><see cref="Application.Main.BankingModule.Services.IMainService"/></returns>
        public List<BankAccountDTO> FindBankAccounts()
        {
            return _bankAppService.FindBankAccounts();
        }
        /// <summary>
        /// <see cref="Application.Main.BankingModule.Services.IMainService"/>
        /// </summary>
        /// <param name="bankAccountId"><see cref="Application.Main.BankingModule.Services.IMainService"/></param>
        /// <returns><see cref="Application.Main.BankingModule.Services.IMainService"/></returns>
        public List<BankActivityDTO> FindBankAccountActivities(Guid bankAccountId)
        {
            return _bankAppService.FindBankAccountActivities(bankAccountId);
        }
        /// <summary>
        /// <see cref="Application.Main.BankingModule.Services.IMainService"/>
        /// </summary>
        /// <param name="from"><see cref="Application.Main.BankingModule.Services.IMainService"/></param>
        /// <param name="to"><see cref="Application.Main.BankingModule.Services.IMainService"/></param>
        /// <param name="amount"><see cref="Application.Main.BankingModule.Services.IMainService"/></param>
        public void PerformTransfer(BankAccountDTO from, BankAccountDTO to, decimal amount)
        {
            _bankAppService.PerformBankTransfer(from, to, amount);
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// <see cref="M:System.IDisposable.Dispose"/>
        /// </summary>
        public void Dispose()
        {
            //dispose all resources
            _bankAppService.Dispose();
        }
        #endregion
    }
}
