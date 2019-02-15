using BooksStore.WebUI.Infrastructure.Abstract;
using BooksStore.WebUI.Models;
using System.Web.Mvc;

namespace BooksStore.WebUI.Controllers
{
    public class AccountController : Controller
    {
        IAuthProvider authProvider;

        public AccountController(IAuthProvider authProvider) => this.authProvider = authProvider;
        // GET: Account
        public ViewResult Login() => View();

        [HttpPost]
        public ActionResult Login(AccountLoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if(authProvider.Authenticate(model.UserName, model.Password))
                    return Redirect(returnUrl ?? Url.Action("Index","Admin"));
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }
            else
                return View();
        }

        public RedirectToRouteResult Logout()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                authProvider.SignOut();
                return RedirectToAction("Index", "Home");
            }
            else
                return RedirectToAction("Login");
        }

        protected override void Dispose(bool disposing)
        {
            authProvider.Dispose();
            base.Dispose(disposing);
        }
    }
}