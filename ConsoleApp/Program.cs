using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Use {AppSettings.ConfigName} environment, Url: {AppSettings.Url}!");
            Console.WriteLine($"ConnectionString: {AppSettings.ConnectionString} environment");
            Console.WriteLine($"Credential: {AppSettings.UserName}--{AppSettings.Password}");
            Console.ReadKey();
        }
    }
}
