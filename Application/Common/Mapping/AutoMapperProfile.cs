using Application.Accounts.Commands;
using Application.Accounts.Dto;
using Application.Authenticates.Dto;
using Application.Authenticates.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Account, AccountDto>();

            // Account -> AuthenticateDto 
            CreateMap<AccountDto, AuthenticateDto>();
            // Authenticate -> Account
            CreateMap<Authenticate, AccountDto>();

            // UpdateRequest -> Account
            CreateMap<UpdateAccountCommand, Account>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        return true;
                    }
                ));
        }
    }
}
