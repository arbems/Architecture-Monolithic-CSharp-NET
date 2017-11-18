namespace Nlayer.Samples.NLayerApp.Infrastructure.Crosscutting.NetFramework.Adapter
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Nlayer.Samples.NLayerApp.Infrastructure.Crosscutting.Adapter;

    /// <summary>
    /// Automapper type adapter implementation
    /// </summary>
    public class AutomapperTypeAdapter
        :ITypeAdapter
    {
        #region ITypeAdapter Members

        /// <summary>
        /// <see cref="Nlayer.Samples.NLayerApp.Infrastructure.Crosscutting.Adapter.ITypeAdapter"/>
        /// </summary>
        /// <typeparam name="TSource"><see cref="Nlayer.Samples.NLayerApp.Infrastructure.Crosscutting.Adapter.ITypeAdapter"/></typeparam>
        /// <typeparam name="TTarget"><see cref="Nlayer.Samples.NLayerApp.Infrastructure.Crosscutting.Adapter.ITypeAdapter"/></typeparam>
        /// <param name="source"><see cref="Nlayer.Samples.NLayerApp.Infrastructure.Crosscutting.Adapter.ITypeAdapter"/></param>
        /// <returns><see cref="Nlayer.Samples.NLayerApp.Infrastructure.Crosscutting.Adapter.ITypeAdapter"/></returns>
        public TTarget Adapt<TSource, TTarget>(TSource source)
            where TSource : class
            where TTarget : class, new()
        {
            return Mapper.Map<TSource, TTarget>(source);
        }

        /// <summary>
        /// <see cref="Nlayer.Samples.NLayerApp.Infrastructure.Crosscutting.Adapter.ITypeAdapter"/>
        /// </summary>
        /// <typeparam name="TTarget"><see cref="Nlayer.Samples.NLayerApp.Infrastructure.Crosscutting.Adapter.ITypeAdapter"/></typeparam>
        /// <param name="source"><see cref="Nlayer.Samples.NLayerApp.Infrastructure.Crosscutting.Adapter.ITypeAdapter"/></param>
        /// <returns><see cref="Nlayer.Samples.NLayerApp.Infrastructure.Crosscutting.Adapter.ITypeAdapter"/></returns>
        public TTarget Adapt<TTarget>(object source) where TTarget : class, new()
        {
            return Mapper.Map<TTarget>(source);
        }

        #endregion
    }
}
