//RenaperService/Filters/AllowAnonymousAttribute.cs
namespace RenaperService.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class AllowAnonymousAttribute : Attribute
    {
    }
}