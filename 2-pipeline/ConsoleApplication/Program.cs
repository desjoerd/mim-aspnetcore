using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            var host = new WebHostBuilder()
                        .UseContentRoot(Directory.GetCurrentDirectory())
                        .UseKestrel()
                        .UseStartup<Startup>()
                        .Build();

            host.Run();
        }
    }
}
