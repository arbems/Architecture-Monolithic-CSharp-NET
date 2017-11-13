﻿namespace Nlayer.Samples.NLayerApp.Infrastructure.Data.Main.UnitOfWork.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    using Nlayer.Samples.NLayerApp.Domain.Main.ERPModule.Aggregates.CountryAgg;

    /// <summary>
    /// The country entity type configuration
    /// </summary>
    class CountryEntityConfiguration
        :EntityTypeConfiguration<Country>
    {
        /// <summary>
        /// Create a new instance of Country entity type configuration
        /// </summary>
        public CountryEntityConfiguration()
        {
            //configure key and properties
            this.HasKey(c => c.Id);

            this.Property(c => c.CountryName)
                .HasMaxLength(50)
                .IsRequired();

            this.Property(c => c.CountryISOCode)
                .HasMaxLength(10)
                .IsRequired();
        }
    }
}
