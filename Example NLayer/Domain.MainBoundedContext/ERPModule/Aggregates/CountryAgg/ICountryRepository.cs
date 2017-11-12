namespace Nlayer.Samples.ExampleNlayer.Domain.MainBoundedContext.ERPModule.Aggregates.CountryAgg
{
    using Nlayer.Samples.ExampleNlayer.Domain.Seedwork;

    /// <summary>
    /// Base contract for country repository
    /// <see cref="Nlayer.Samples.ExampleNlayer.Domain.Seedwork.IRepository{Country}"/>
    /// </summary>
    public interface ICountryRepository
        :IRepository<Country>
    {
    }
}
