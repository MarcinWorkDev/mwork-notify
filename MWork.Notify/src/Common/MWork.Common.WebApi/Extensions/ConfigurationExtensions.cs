using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

namespace MWork.Common.WebApi.Extensions
{
    public static class ConfigurationExtensions
    {
        public static T GetSecret<T>(this IConfiguration configuration, string key)
        {
            const string dockerSecretPath = "/run/secrets/";

            var variable = configuration.GetValue<string>(key);
            if (variable.StartsWith(dockerSecretPath))
            {
                if (Directory.Exists(dockerSecretPath) == false || File.Exists(variable) == false)
                {
                    throw new Exception("Docker secrets file not found!");
                }

                variable = File.ReadAllText(variable);
            }

            return (T)Convert.ChangeType(variable, typeof(T));
        }

        public static string GetSecret(this IConfiguration configuration, string key)
        {
            return configuration.GetSecret<string>(key);
        }
    }
}