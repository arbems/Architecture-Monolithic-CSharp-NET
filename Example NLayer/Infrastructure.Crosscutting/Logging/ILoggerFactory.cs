﻿namespace Nlayer.Samples.NLayerApp.Infrastructure.Crosscutting.Logging
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Base contract for Log abstract factory
    /// </summary>
    public interface ILoggerFactory
    {
        /// <summary>
        /// Create a new ILog
        /// </summary>
        /// <returns>The ILog created</returns>
        ILogger Create();
    }
}
