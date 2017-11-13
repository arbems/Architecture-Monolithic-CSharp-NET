namespace Nlayer.Samples.NLayerApp.Infrastructure.Crosscutting.NetFramework.Logging
{
    using Nlayer.Samples.NLayerApp.Infrastructure.Crosscutting.Logging;

    /// <summary>
    /// A Trace Source base, log factory
    /// </summary>
    public class TraceSourceLogFactory
        :ILoggerFactory
    {
        /// <summary>
        /// Create the trace source log
        /// </summary>
        /// <returns>New ILog based on Trace Source infrastructure</returns>
        public ILogger Create()
        {
            return new TraceSourceLog();
        }
    }
}
