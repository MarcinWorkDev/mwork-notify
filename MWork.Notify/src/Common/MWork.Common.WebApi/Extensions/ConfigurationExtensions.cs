using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using MWork.Common.WebApi.Helpers;

namespace MWork.Common.WebApi.Extensions
{
    public static class ConfigurationExtensions
    {
        public static object GetSecret(this IConfiguration configuration, Type type, string key, IFileManager fileManager = null)
        {
            fileManager ??= FileManager.GetInstance;
            
            const string dockerSecretPath = "/run/secrets/";

            var variable = configuration.GetValue<string>(key);
            if (variable?.StartsWith(dockerSecretPath) == true)
            {
                if (fileManager.FileExists(variable) == false)
                {
                    throw new FileNotFoundException("Docker secret file not found!", variable);
                }

                variable = fileManager.ReadAllText(variable);
            }

            return Convert.ChangeType(variable, type);
        }

        public static string GetSecret(this IConfiguration configuration, string key, IFileManager fileManager = null)
        {
            return configuration.GetSecret<string>(key, fileManager);
        }
        
        public static T GetSecret<T>(this IConfiguration configuration, string key, IFileManager fileManager = null)
        {
            return (T)configuration.GetSecret(typeof(T), key, fileManager);
        }

    }
}