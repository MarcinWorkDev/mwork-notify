using System.Collections.Generic;

namespace MWork.Common.Sdk.WebApi.Framework.RabbitMq
{
    public class RabbitMqOptions
    {
        public string VirtualHost { get; set; } = "/";

        public string Username { get; set; } = "guest";

        public string Password { get; set; } = "guest";

        public int Port { get; set; } = 5672;

        public List<string> Hostnames { get; set; } = new List<string> {"localhost"};
    }
}