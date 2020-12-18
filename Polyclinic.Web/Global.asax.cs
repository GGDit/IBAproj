using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using Polyclinic.BLL.Infrastructure;
using Polyclinic.Web.Infrastructure;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Polyclinic.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            string connectionString = ConfigurationManager.ConnectionStrings["Polyclinic"].ConnectionString;

            NinjectModule recordModule = new PolyclinicNinjectModule();
            NinjectModule serviceModule = new ServiceModule(connectionString);
            var kernel = new StandardKernel(recordModule, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
