using Store.DAL.Abstract;
using Store.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Store.WebUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        IUserRepository user;

        public AccountController(IUserRepository user)
        {
            this.user = user;
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if(user.Login(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                } 
                else 
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            } 
            else
            {
                return View();
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Admin");
        }
        // Change Password
        // Forget password
	}
}