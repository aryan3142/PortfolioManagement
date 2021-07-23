using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationPortfolioManagement.Models
{
    public interface ILoggerManager
    {
        public void LogInformation(string message); //Signature
    }
}
