using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using ConsoleAppFramework;

namespace ConsoleAppExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Host.CreateDefaultBuilder().RunConsoleAppFrameworkAsync(args);
        }
    }
}
