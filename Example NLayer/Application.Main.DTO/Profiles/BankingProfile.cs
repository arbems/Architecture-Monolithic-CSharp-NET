namespace Nlayer.Samples.ExampleNlayer.Application.MainBoundedContext.DTO.Profiles
{
    using AutoMapper;
    using Nlayer.Samples.NLayerApp.Application.Main.DTO;
    using Nlayer.Samples.NLayerApp.Domain.Main.BankingModule.Aggregates.BankAccountAgg;

    class BankingProfile
        : Profile
    {
			public BankingProfile()
			{
				var config = new MapperConfiguration(cfg =>
				{
					cfg.CreateMap<BankAccountActivity, BankActivityDTO>();

                    cfg.CreateMap<BankAccount, BankAccountDTO>()
                    .ForMember
                            (dto => dto.BankAccountNumber, mc => mc.MapFrom(e => e.Iban));
                });
			}
    }
}
