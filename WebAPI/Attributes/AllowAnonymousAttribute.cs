using System;

namespace Web.API.Atributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class AllowAnonymousAttribute: Attribute
    {
    }
}
