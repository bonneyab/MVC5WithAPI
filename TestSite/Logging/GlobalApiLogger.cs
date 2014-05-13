using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using Web.Core;

namespace TestSite.Logging
{
    //http://www.asp.net/web-api/overview/web-api-routing-and-actions/web-api-global-error-handling
    public class GlobalApiLogger : ExceptionLogger
    {
        private readonly ILoggingService _logger;

        public GlobalApiLogger(ILoggingService logger)
        {
            _logger = logger;
        }

        public override void Log(ExceptionLoggerContext context)
        {
            _logger.Error(context.Exception);
        }
    }
}