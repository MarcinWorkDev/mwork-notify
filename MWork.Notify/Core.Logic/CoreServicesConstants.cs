using System.Reflection;

namespace MWork.Notify.Core.Logic
{
    public static class CoreServicesConstants
    {
        public static Assembly Assembly => typeof(CoreServicesConstants).GetTypeInfo().Assembly;
    }
}