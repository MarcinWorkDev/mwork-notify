using Microsoft.Extensions.Configuration;
using MWork.Notify.Common.Api;
using MWork.Notify.Common.Api.Runtime;

namespace MWork.Notify.Template.Api
{
    public class Program
    {
        public static void Main(string[] args) => MWorkNotifyRuntime<Startup>.Run(args);
    }
    
    public class Startup : MWorkNotifyStartup
    {
        public Startup(IConfiguration configuration) : base(configuration, true)
        {
        }
    }
}