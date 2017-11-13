namespace Nlayer.Samples.NLayerApp.Domain.Main.ERPModule.Aggregates.CountryAgg
{
    using Nlayer.Samples.NLayerApp.Domain.Core;

    /// <summary>
    /// Base contract for country repository
    /// <see cref="Nlayer.Samples.NLayerApp.Domain.Core.IRepository{Country}"/>
    /// </summary>
    public interface ICountryRepository
        :IRepository<Country>
    {
    }
}
