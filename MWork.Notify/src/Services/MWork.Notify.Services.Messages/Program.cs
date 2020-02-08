using MWork.Common.WebApi.Runtime;

namespace MWork.Notify.Services.Messages
{
    public class Program
    {
        public static void Main(string[] args) => MWorkNotifyRuntime<Startup>.Run(args);
    }
}