using Application.Accounts.Commands;
using Application.Accounts.Dto;
using Application.Authenticates.Dto;
using Application.Authenticates.Queries;
using Application.Permissions.Dto;
using AutoMapper;
using Domain.Entities;
using System.Reflection;

namespace Application.Common.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
            CreateMap<Permission, PermissionDto>();
            CreateMap<GroupPermission, Application.GroupPermissions.Dto.GroupPermissionDto>();
        }
        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            //    var mapFromType = typeof(IMapFrom<>);

            //    var mappingMethodName = nameof(IMapFrom<object>.Mapping);

            //    bool HasInterface(Type t) => t.IsGenericType && t.GetGenericTypeDefinition() == mapFromType;

            //    var types = assembly.GetExportedTypes().Where(t => t.GetInterfaces().Any(HasInterface)).ToList();

            //    var argumentTypes = new Type[] { typeof(Profile) };

            //    foreach (var type in types)
            //    {
            //        var instance = Activator.CreateInstance(type);

            //        var methodInfo = type.GetMethod(mappingMethodName);

            //        if (methodInfo != null)
            //        {
            //            methodInfo.Invoke(instance, new object[] { this });
            //        }
            //        else
            //        {
            //            var interfaces = type.GetInterfaces().Where(HasInterface).ToList();

            //            if (interfaces.Count > 0)
            //            {
            //                foreach (var @interface in interfaces)
            //                {
            //                    var interfaceMethodInfo = @interface.GetMethod(mappingMethodName, argumentTypes);

            //                    interfaceMethodInfo?.Invoke(instance, new object[] { this });
            //                }
            //            }
            //        }
            //    }

            //    //
            //    var mapToType = typeof(IMapTo<>);

            //    var mappingToMethodName = nameof(IMapTo<object>.Mapping);

            //    bool HasInterfaceMapTo(Type t) => t.IsGenericType && t.GetGenericTypeDefinition() == mapToType;

            //    var mapToTypes = assembly.GetExportedTypes().Where(t => t.GetInterfaces().Any(HasInterfaceMapTo)).ToList();

            //    var argumentMapToTypes = new Type[] { typeof(Profile) };

            //    foreach (var type in mapToTypes)
            //    {
            //        var instance = Activator.CreateInstance(type);

            //        var methodInfo = type.GetMethod(mappingToMethodName);

            //        if (methodInfo != null)
            //        {
            //            methodInfo.Invoke(instance, new object[] { this });
            //        }
            //        else
            //        {
            //            var interfaces = type.GetInterfaces().Where(HasInterfaceMapTo).ToList();

            //            if (interfaces.Count > 0)
            //            {
            //                foreach (var @interface in interfaces)
            //                {
            //                    var interfaceMethodInfo = @interface.GetMethod(mappingToMethodName, argumentMapToTypes);

            //                    interfaceMethodInfo?.Invoke(instance, new object[] { this });
            //                }
            //            }
            //        }
            //    }


            //    //Basic map
            //    var basicMapToType = typeof(IBasicMapTo<>);

            //    var basicMappingToMethodName = nameof(IMapTo<object>.Mapping);

            //    bool HasInterfaceBaicMapTo(Type t) => t.IsGenericType && t.GetGenericTypeDefinition() == basicMapToType;

            //    var basicMapToTypes = assembly.GetExportedTypes().Where(t => t.GetInterfaces().Any(HasInterfaceBaicMapTo)).ToList();

            //    var argumentBasicMapToTypes = new Type[] { typeof(Profile) };

            //    foreach (var type in basicMapToTypes)
            //    {
            //        var instance = Activator.CreateInstance(type);

            //        var methodInfo = type.GetMethod(basicMappingToMethodName);

            //        if (methodInfo != null)
            //        {
            //            methodInfo.Invoke(instance, new object[] { this });
            //        }
            //        else
            //        {
            //            var interfaces = type.GetInterfaces().Where(HasInterfaceBaicMapTo).ToList();

            //            if (interfaces.Count > 0)
            //            {
            //                foreach (var @interface in interfaces)
            //                {
            //                    var interfaceMethodInfo = @interface.GetMethod(basicMappingToMethodName, argumentBasicMapToTypes);

            //                    interfaceMethodInfo?.Invoke(instance, new object[] { this });
            //                }
            //            }
            //        }
            //    }
        }
}
}
