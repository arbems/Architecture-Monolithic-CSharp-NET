namespace Domain.Main.BankingModule.Aggregates.BankAccountAgg
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Domain.Core;
    using Domain.Main.Resources;

    /// <summary>
    /// The bank transferLog representation
    /// </summary>
    public class BankAccountActivity
        :Entity
    {
        #region Properties

        /// <summary>
        /// Get or set the bank account identifier
        /// </summary>
        public Guid BankAccountId { get; set; }

        /// <summary>
        /// The bank transferLog date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The bank transferLog amount
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Get or set the activity description
        /// </summary>
        public string ActivityDescription { get; set; }

        #endregion
    }
}
