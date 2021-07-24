using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailySharePriceMS.Loggers
{
    public interface ILoggerManager
    {
        public void LogInformation(string message);
    }
}
