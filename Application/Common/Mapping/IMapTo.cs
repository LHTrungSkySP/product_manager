using AutoMapper;

namespace Application.Common.Mapping
{
    public interface IMapTo<T>
    {
        /// <summary>
        /// This interface implement to ignore null field when update
        /// </summary>
        /// <param name="profile"></param>
        void Mapping(Profile profile) => profile.CreateMap(GetType(), typeof(T)).ForAllMembers(opts =>
            opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}
