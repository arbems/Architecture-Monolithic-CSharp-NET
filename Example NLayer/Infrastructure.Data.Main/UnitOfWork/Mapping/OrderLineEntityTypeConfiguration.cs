namespace Infrastructure.Data.Main.UnitOfWork.Mapping
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Domain.Main.ERPModule.Aggregates.OrderAgg;
    using System.Data.Entity.ModelConfiguration;

    /// <summary>
    /// The orderline entity type configuration
    /// </summary>
    class OrderLineEntityTypeConfiguration
        :EntityTypeConfiguration<OrderLine>
    {
        public OrderLineEntityTypeConfiguration()
        {
            this.HasKey(ol => ol.Id);

            this.Property(ol => ol.UnitPrice)
                .HasPrecision(10, 2);

            this.Property(ol => ol.Discount)
                .HasPrecision(10, 2);

            this.Ignore(ol => ol.TotalLine);

            //Associations
            this.HasRequired(p => p.Product)
                .WithMany()
                .HasForeignKey(ol => ol.ProductId);
        }
    }
}
