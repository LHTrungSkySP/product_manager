using AutoMapper;
using BanHang.Entities;
using BanHang.Models.Accounts;

namespace BanHang.Helpers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile() 
        {
            // Account -> AuthenticateResponse 
            CreateMap<Account, AuthenticateResponse>();
            // RegisterRequest -> Account
            CreateMap<RegisterRequest, Account>();

            // UpdateRequest -> Account
            CreateMap<UpdateRequest, Account>()
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
