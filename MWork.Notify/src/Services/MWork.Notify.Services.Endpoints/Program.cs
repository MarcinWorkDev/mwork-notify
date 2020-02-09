using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MWork.Common.WebApi.Runtime;

namespace MWork.Notify.Services.Endpoints
{
    public class Program
    {
        public static void Main(string[] args) => MWorkNotifyRuntime<Startup>.Run(args);
    }
}