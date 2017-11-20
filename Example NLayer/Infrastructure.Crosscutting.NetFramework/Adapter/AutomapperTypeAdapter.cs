namespace Infrastructure.Crosscutting.NetFramework.Adapter
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Infrastructure.Crosscutting.Adapter;

    /// <summary>
    /// Automapper type adapter implementation
    /// </summary>
    public class AutomapperTypeAdapter
        :ITypeAdapter
    {
        #region ITypeAdapter Members

        /// <summary>
        /// <see cref="Infrastructure.Crosscutting.Adapter.ITypeAdapter"/>
        /// </summary>
        /// <typeparam name="TSource"><see cref="Infrastructure.Crosscutting.Adapter.ITypeAdapter"/></typeparam>
        /// <typeparam name="TTarget"><see cref="Infrastructure.Crosscutting.Adapter.ITypeAdapter"/></typeparam>
        /// <param name="source"><see cref="Infrastructure.Crosscutting.Adapter.ITypeAdapter"/></param>
        /// <returns><see cref="Infrastructure.Crosscutting.Adapter.ITypeAdapter"/></returns>
        public TTarget Adapt<TSource, TTarget>(TSource source)
            where TSource : class
            where TTarget : class, new()
        {
            return Mapper.Map<TSource, TTarget>(source);
        }

        /// <summary>
        /// <see cref="Infrastructure.Crosscutting.Adapter.ITypeAdapter"/>
        /// </summary>
        /// <typeparam name="TTarget"><see cref="Infrastructure.Crosscutting.Adapter.ITypeAdapter"/></typeparam>
        /// <param name="source"><see cref="Infrastructure.Crosscutting.Adapter.ITypeAdapter"/></param>
        /// <returns><see cref="Infrastructure.Crosscutting.Adapter.ITypeAdapter"/></returns>
        public TTarget Adapt<TTarget>(object source) where TTarget : class, new()
        {
            return Mapper.Map<TTarget>(source);
        }

        #endregion
    }
}
