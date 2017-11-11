//===================================================================================
// Microsoft Developer & Platform Evangelism
//=================================================================================== 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//===================================================================================
// Copyright (c) Microsoft Corporation.  All Rights Reserved.
// This code is released under the terms of the MS-LPL license, 
// http://microsoftExampleNlayer.codeplex.com/license
//===================================================================================

namespace Microsoft.Samples.ExampleNlayer.Application.MainBoundedContext.DTO.Profiles
{
    using AutoMapper;
    using Microsoft.Samples.ExampleNlayer.Domain.MainBoundedContext.ERPModule.Aggregates.CountryAgg;
    using Microsoft.Samples.ExampleNlayer.Domain.MainBoundedContext.ERPModule.Aggregates.CustomerAgg;
    using Microsoft.Samples.ExampleNlayer.Domain.MainBoundedContext.ERPModule.Aggregates.OrderAgg;
    using Microsoft.Samples.ExampleNlayer.Domain.MainBoundedContext.ERPModule.Aggregates.ProductAgg;

    class ErpProfile
        :Profile
    {
        public ErpProfile()
        {
					var config = new MapperConfiguration(cfg => {
						cfg.CreateMap<Book, BookDTO>();
						cfg.CreateMap<Country, CountryDTO>();
						cfg.CreateMap<Customer, CustomerListDTO>();
						cfg.CreateMap<Customer, CustomerDTO>();
						cfg.CreateMap<Product, ProductDTO>();
						cfg.CreateMap<Software, SoftwareDTO>();
					});

			Mapper.Initialize(cfg =>
			{
				cfg.CreateMap<Order, OrderListDTO>()
				.ForMember
						(dto => dto.TotalOrder, mc => mc.MapFrom(e => e.GetOrderTotal()))
				.ForMember
						(dto => dto.ShippingAddress, mc => mc.MapFrom(e => e.ShippingInformation.ShippingAddress))
				.ForMember
						(dto => dto.ShippingCity, mc => mc.MapFrom(e => e.ShippingInformation.ShippingCity))
				.ForMember
						(dto => dto.ShippingName, mc => mc.MapFrom(e => e.ShippingInformation.ShippingName))
				.ForMember
						(dto => dto.ShippingZipCode, mc => mc.MapFrom(e => e.ShippingInformation.ShippingZipCode));
			});

			Mapper.Initialize(cfg =>
			{
				cfg.CreateMap<Order, OrderDTO>()
				.ForMember
						(dto => dto.ShippingAddress, (map) => map.MapFrom(o => o.ShippingInformation.ShippingAddress))
				.ForMember
						(dto => dto.ShippingCity, (map) => map.MapFrom(o => o.ShippingInformation.ShippingCity))
				.ForMember
						(dto => dto.ShippingName, (map) => map.MapFrom(o => o.ShippingInformation.ShippingName))
				.ForMember
						(dto => dto.ShippingZipCode, (map) => map.MapFrom(o => o.ShippingInformation.ShippingZipCode));
			});

			Mapper.Initialize(cfg =>
			{
				cfg.CreateMap<OrderLine, OrderLineDTO>()
				.ForMember
						(dto => dto.Discount, mc => mc.MapFrom(o => o.Discount * 100));
			});
        }
    }
}
