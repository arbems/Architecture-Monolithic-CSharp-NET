namespace Nlayer.Samples.NLayerApp.Infrastructure.Data.Main.UnitOfWork.Mapping
{

    using System.Data.Entity.ModelConfiguration;
    using Nlayer.Samples.NLayerApp.Domain.Main.ERPModule.Aggregates.CustomerAgg;

    /// <summary>
    /// The picture entity type configuration
    /// </summary>
    class PictureEntityConfiguration
        :EntityTypeConfiguration<Picture>
    {
        /// <summary>
        /// Create a new instance of picture entity type configuration
        /// </summary>
        public PictureEntityConfiguration()
        {
            this.HasKey(p => p.Id);

            this.Property(p => p.RawPhoto)
                .IsOptional();

            this.ToTable("Customers");
        }
    }
}
