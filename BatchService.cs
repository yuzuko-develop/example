using System;
using Microsoft.Extensions.Configuration;
using ZLogger;

namespace ConsoleAppFramework
{
    class BatchService : ConsoleAppBase
    {
        private readonly IConfiguration config;

        public BatchService(IConfiguration iconfig)
        {
            config = iconfig;

        }

        [Command("exec")]
        public void Exec()
        {
            Context.Logger.ZLogDebug("Hello Hosting Batch Application!!!");
            string s = config.GetValue<string>("Logging:ZLoggerRollingFile:path", "").Trim().TrimEnd('/', ' ', '\\');
            Context.Logger.ZLogDebug("log directory={0}", s);
        }
    }
}