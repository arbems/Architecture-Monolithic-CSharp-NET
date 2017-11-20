namespace Application.Main.DTO.Profiles
{
    using AutoMapper;
    using Domain.Main.ERPModule.Aggregates.CountryAgg;
    using Domain.Main.ERPModule.Aggregates.CustomerAgg;
    using Domain.Main.ERPModule.Aggregates.OrderAgg;
    using Domain.Main.ERPModule.Aggregates.ProductAgg;

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

                cfg.CreateMap<Order, OrderDTO>()
                .ForMember
                        (dto => dto.ShippingAddress, (map) => map.MapFrom(o => o.ShippingInformation.ShippingAddress))
                .ForMember
                        (dto => dto.ShippingCity, (map) => map.MapFrom(o => o.ShippingInformation.ShippingCity))
                .ForMember
                        (dto => dto.ShippingName, (map) => map.MapFrom(o => o.ShippingInformation.ShippingName))
                .ForMember
                        (dto => dto.ShippingZipCode, (map) => map.MapFrom(o => o.ShippingInformation.ShippingZipCode));

                cfg.CreateMap<OrderLine, OrderLineDTO>()
                .ForMember
                        (dto => dto.Discount, mc => mc.MapFrom(o => o.Discount * 100));

            });
            

        }
    }
}
