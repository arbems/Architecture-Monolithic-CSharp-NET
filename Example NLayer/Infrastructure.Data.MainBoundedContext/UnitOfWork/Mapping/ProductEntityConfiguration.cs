namespace Nlayer.Samples.NLayerApp.Infrastructure.Data.Main.UnitOfWork.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    using Nlayer.Samples.NLayerApp.Domain.Main.ERPModule.Aggregates.ProductAgg;

    /// <summary>
    /// The product entity type configuration
    /// </summary>
    class ProductEntityConfiguration
        :EntityTypeConfiguration<Product>
    {
        /// <summary>
        /// Create a new instance of product entity configuration
        /// </summary>
        public ProductEntityConfiguration()
        {
            //configure key and properties

            this.HasKey(p => p.Id);

            this.Property(p => p.Title)
                .IsRequired();

            this.Property(p => p.UnitPrice)
                .HasPrecision(10, 2);

            this.ToTable("Products");
        }
    }
}
