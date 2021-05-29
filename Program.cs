using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ConsoleAppFramework;
using ZLogger;
using Cysharp.Text;

namespace ConsoleAppExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Host
                .CreateDefaultBuilder()
                .ConfigureLogging((context, logging) =>
                {
                    var prefixFormat = ZString.PrepareUtf8<string, LogLevel>("[{0}][{1}]");

                    logging.ClearProviders();
                    logging.AddZLoggerConsole(options =>
                    {
                        options.PrefixFormatter = (writer, info) =>
                            prefixFormat.FormatTo(ref writer, info.Timestamp.LocalDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff"), info.LogLevel);
                    });

                    string path = context.Configuration.GetValue<string>("Logging:ZLoggerRollingFile:path", "").Trim().TrimEnd('/', ' ', '\\');
                    if (!string.IsNullOrWhiteSpace(path)) path += "/";
                    int rollSizeKB = context.Configuration.GetValue<int>("Logging:ZLoggerRollingFile:rollSizeKB", 1024);
                    logging.AddZLoggerRollingFile((dt, x) =>
                        path + $"{dt.ToLocalTime():yyyy-MM-dd}_{x:000}.log",
                        x => x.ToLocalTime().Date,
                        rollSizeKB,
                        options =>
                        {
                            options.PrefixFormatter = (writer, info) =>
                                prefixFormat.FormatTo(ref writer, info.Timestamp.LocalDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff"), info.LogLevel);
                        });
                })
                .RunConsoleAppFrameworkAsync(args);
        }
    }
}
