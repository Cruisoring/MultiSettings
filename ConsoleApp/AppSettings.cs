using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ConsoleApp
{
    public class AppSettings
    {
        public const string CONFIG_NAME_KEY = "ConfigName";
        static AppSettings()
        {
            //The configName can be specified by calling System.Environment.SetEnvironmentVariable("ConfigName", "..."):
            string configName = Environment.GetEnvironmentVariable(CONFIG_NAME_KEY) ??
                Regex.Match(Environment.CurrentDirectory, "\\\\bin\\\\([^\\\\]*)\\\\?").Groups[1].Value;

            if (!File.Exists($"configurations/{configName.ToLower()}.json"))
            {
                ConfigName = "Default";

                Current = new ConfigurationBuilder()
                    .AddJsonFile("configurations/default.json")
                    .Build();
                Console.WriteLine($"There is no JSON setting file {configName.ToLower()}.json found under configurations folder.");
            }
            else
            {
                ConfigName = configName;

                Current = new ConfigurationBuilder()
                    .AddJsonFile("configurations/default.json")
                    .AddJsonFile($"configurations/{configName}.json", true)
                    .Build();
            }
        }

        public static string ConfigName { get; private set; }

        public static IConfiguration Current { get; private set; }

        public static String ConnectionString => Current["ConnectionString"];
        public static String Url => Current["Url"];

        public static String UserName => Current["Credential:UserName"];
        public static String Password => Current["Credential:Password"];
    }

}
