using Application.Permissions.Dto;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mapping
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile)
        {
            //if (typeof(T) == typeof(Permission))
            //{
            //    profile.CreateMap<Permission, PermissionDto>()
            //        .ForMember(dest => dest.GroupPermissions, opt => opt.MapFrom(src =>
            //            src.AssignPermissions.Select(ap => ap.GroupPermission).ToList()
            //        ));
            //} 
            //else
            //{
            //}
                profile.CreateMap(typeof(T), GetType());
        }
    }
}
