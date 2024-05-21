
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
            //    profile.CreateMap<Permission, Permissions.Dto.PermissionDto>()
            //        .ForMember(dest => dest.GroupPermissions, opt => opt.MapFrom(src =>
            //            src.AssignPermissions.Select(ap => ap.GroupPermission).ToList()
            //        ));
            //}
            //else if (typeof(T) == typeof(GroupPermission))
            //{
            //    profile.CreateMap<GroupPermission, GroupPermissions.Dto.GroupPermissionDto>()
            //        .ForMember(dest => dest.Permissions, opt => opt.MapFrom(src =>
            //            src.AssignPermissions.Select(ap => ap.Permission).ToList()
            //        ))
            //        .ForMember(dest => dest.Accounts, opt => opt.MapFrom(src =>
            //            src.AssignGroups.Select(ap => ap.GroupPermission).ToList()
            //        ));
            //}
            //else
            //{
            //    profile.CreateMap(typeof(T), GetType());
            //}
            profile.CreateMap(typeof(T), GetType()).ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) =>
                {
                    return srcMember != null;
                });
            });
        }
    }
}
