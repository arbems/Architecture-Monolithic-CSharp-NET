namespace Nlayer.Samples.NLayerApp.Infrastructure.Data.Main.UnitOfWork.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    using Nlayer.Samples.NLayerApp.Domain.Main.ERPModule.Aggregates.ProductAgg;

    /// <summary>
    /// Book entity type configuration
    /// </summary>
    class BookEntityTypeConfiguration
        :EntityTypeConfiguration<Book>
    {
        public BookEntityTypeConfiguration()
        {
            this.Property(b => b.ISBN)
                .IsRequired();
            this.Property(b => b.Publisher)
                .IsRequired();

            this.ToTable("Books");
        }
    }
}
