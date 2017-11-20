namespace Infrastructure.Data.Main.UnitOfWork.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    using Domain.Main.ERPModule.Aggregates.ProductAgg;

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
