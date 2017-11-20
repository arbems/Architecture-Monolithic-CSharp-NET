namespace Application.Main.DTO.Profiles
{
    using AutoMapper;
    using Application.Main.DTO;
    using Domain.Main.BankingModule.Aggregates.BankAccountAgg;

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
