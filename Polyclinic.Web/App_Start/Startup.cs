using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Polyclinic.BLL.Interfaces;
using Polyclinic.BLL.Services;
using System.Web.Mvc;

[assembly: OwinStartup(typeof(Polyclinic.Web.App_Start.Startup))]

namespace Polyclinic.Web.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<IUserService>(CreateUserService);
            //устанавливаем аутентификацию на основе куки
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Home/Index")//неавторизованные пользователи направляются сюда
            });
        }

        private IUserService CreateUserService()
        {
            return (UserService)DependencyResolver.Current.GetService(typeof(UserService));
        }
    }
}
