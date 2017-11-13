﻿namespace Nlayer.Samples.NLayerApp.Infrastructure.Data.Main.UnitOfWork.Mapping
{
	using System.Data.Entity.ModelConfiguration;
	using Nlayer.Samples.NLayerApp.Domain.Main.ERPModule.Aggregates.OrderAgg;
	using System.ComponentModel.DataAnnotations.Schema;

	/// <summary>
	/// The order entity configuration
	/// </summary>
	internal class OrderEntityConfiguration
		: EntityTypeConfiguration<Order>
	{
		public OrderEntityConfiguration()
		{
			this.HasKey(o => o.Id);

			this.Property(o => o.SequenceNumberOrder)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			this.Ignore(o => o.OrderNumber);

			//order->orderline navigation
			this.HasMany(o => o.OrderLines)
				.WithRequired()
				.HasForeignKey(ol => ol.OrderId)
				.WillCascadeOnDelete(true);
		}
	}
}
