namespace Domain.Main.ERPModule.Aggregates.CountryAgg
{
    using Domain.Core;

    /// <summary>
    /// Base contract for country repository
    /// <see cref="Domain.Core.IRepository{Country}"/>
    /// </summary>
    public interface ICountryRepository
        :IRepository<Country>
    {
    }
}
