namespace Nlayer.Samples.NLayerApp.Domain.Main.ERPModule.Aggregates.CustomerAgg
{

    using System;
    using Nlayer.Samples.NLayerApp.Domain.Core;

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
