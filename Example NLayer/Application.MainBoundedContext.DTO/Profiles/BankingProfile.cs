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
    using Microsoft.Samples.ExampleNlayer.Application.MainBoundedContext.DTO;
    using Microsoft.Samples.ExampleNlayer.Domain.MainBoundedContext.BankingModule.Aggregates.BankAccountAgg;

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
