namespace Nlayer.Samples.ExampleNlayer.Domain.MainBoundedContext.ERPModule.Aggregates.CountryAgg
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Nlayer.Samples.ExampleNlayer.Domain.Seedwork;
    using Nlayer.Samples.ExampleNlayer.Domain.MainBoundedContext.Resources;

    /// <summary>
    /// The country entity
    /// </summary>
    public class Country
        :Entity
    {
        #region Properties

        /// <summary>
        /// Get or set the Country Name
        /// </summary>
        public string CountryName { get; private set; }

        /// <summary>
        /// Get or set the Country ISO Code
        /// </summary>
        public string CountryISOCode { get; private set; }

        #endregion

        #region Constructor

        //required by EF
        public Country() { } 

        public Country(string countryName, string countryISOCode)
        {
            if (String.IsNullOrWhiteSpace(countryName))
                throw new ArgumentNullException("countryName");

            if (String.IsNullOrWhiteSpace(countryISOCode))
                throw new ArgumentNullException("countryISOCode");

            this.CountryName = countryName;
            this.CountryISOCode = countryISOCode;
        }

        #endregion
    }
}
