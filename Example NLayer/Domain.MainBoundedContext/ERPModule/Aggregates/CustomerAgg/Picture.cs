namespace Nlayer.Samples.ExampleNlayer.Domain.MainBoundedContext.ERPModule.Aggregates.CustomerAgg
{

    using System;
    using Nlayer.Samples.ExampleNlayer.Domain.Seedwork;

    /// <summary>
    /// Picture of customer
    /// </summary>
    public class Picture
        :Entity
    {
        #region Properties

        /// <summary>
        /// Get the raw of photo
        /// </summary>
        public byte[] RawPhoto{ get; set; }

        #endregion
    }
}
