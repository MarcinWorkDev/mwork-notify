using System.Reflection;

namespace MWork.Notify.Core.Services
{
    public static class CoreServicesConstants
    {
        public static Assembly Assembly => typeof(CoreServicesConstants).GetTypeInfo().Assembly;
    }
}