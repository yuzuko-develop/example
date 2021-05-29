using System;
using ZLogger;

namespace ConsoleAppFramework
{
    class BatchService : ConsoleAppBase
    {
        [Command("exec")]
        public void Exec()
        {
            Context.Logger.ZLogDebug("Hello Hosting Batch Application!!!");
        }
    }
}