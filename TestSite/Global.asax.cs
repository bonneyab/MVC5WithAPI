using System;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using DataAccess.Repository;
using TestSite.Logging;
using Web.Core;

namespace TestSite
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        //Can't really use dependency injection until it's set up...
        private ILoggingService _logger;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //For some reason this guy sometimes disposed
            //SetupDependencyInjection();
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
        }

        protected void Application_BeginRequest()
        {
            SetupDependencyInjection();
        }

        private void SetupDependencyInjection()
        {
            var builder = DependencyBuilder.SetupDependencyInjection();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IRepository<>));
            builder.RegisterModelBinderProvider();
            builder.RegisterModule(new AutofacWebTypesModule());
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver =
                 new AutofacWebApiDependencyResolver(container);
            //GlobalConfiguration.Configuration.Services.Add(typeof(IExceptionLogger), new Global);
            _logger = DependencyResolver.Current.GetService<ILoggingService>();
            GlobalConfiguration.Configuration.Services.Add(typeof(IExceptionLogger), new GlobalApiLogger(_logger));
            _logger.SetLogger("WebApi");
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //doesn't actually catch most webapi exceptions, see exceptionlogger for that business
            var exception = Server.GetLastError();
            _logger.Error(exception);
        }
    }
}
