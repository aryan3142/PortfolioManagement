using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Reflection;

//Added...
using log4net;
using log4net.Config;

namespace AuthorizationPortfolioManagement.Models
{
    public class LoggerManager : ILoggerManager
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(LoggerManager));
        public LoggerManager()
        {
            try
            {
                XmlDocument log4netConfigfile = new XmlDocument();

                using (var fs = File.OpenRead("log4net.config"))
                {
                    var repo = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
                    log4netConfigfile.Load(fs);
                    XmlConfigurator.Configure(repo, log4netConfigfile["log4net"]);
                    _logger.Info("Logging initiated on authorization");
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Error", ex);
            }
        }
        public void LogInformation(string message)
        {
            _logger.Info(message);
        }

    }
}
