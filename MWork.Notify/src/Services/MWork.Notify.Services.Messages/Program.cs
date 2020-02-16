using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace MWork.Notify.Services.Messages
{
    public class Program
    {
        public static void Main(string[] args)
            => Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>())
                .ConfigureHostConfiguration(o => o.AddCommandLine(args))
                .Build()
                .Run();
    }
}