using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Polyclinic.BLL.Interfaces;
using Polyclinic.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Polyclinic.Web.Controllers
{
    public class AccountController : Controller
    {
        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.returnUrl = Request.UrlReferrer.AbsolutePath;
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
      
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            if(ModelState.IsValid)
            {
                ClaimsIdentity claim = await UserService.AuthenticateAsync(model.Name, model.Password);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    ((ClaimsIdentity)User.Identity).AddClaims(claim.Claims);//?НАдо?
                    
                    
                   
                    
                    return RedirectToAction("Index", "Home");
                }
            }
            return Redirect(returnUrl);

        }
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}