namespace Nlayer.Samples.ExampleNlayer.Application.MainBoundedContext.DTO.Profiles
{
    using AutoMapper;
    using Nlayer.Samples.ExampleNlayer.Application.MainBoundedContext.DTO;
    using Nlayer.Samples.ExampleNlayer.Domain.MainBoundedContext.BankingModule.Aggregates.BankAccountAgg;

    class BankingProfile
        : Profile
    {
			public BankingProfile()
			{
				var config = new MapperConfiguration(cfg =>
				{
					cfg.CreateMap<BankAccountActivity, BankActivityDTO>();
				});

				Mapper.Initialize(cfg =>
				{
					cfg.CreateMap<BankAccount, BankAccountDTO>()
					.ForMember
							(dto => dto.BankAccountNumber, mc => mc.MapFrom(e => e.Iban));
				});
			}
    }
}
