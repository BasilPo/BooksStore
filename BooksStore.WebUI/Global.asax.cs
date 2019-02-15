using BooksStore.Domain.Concrete;
using BooksStore.Domain.Entities;
using BooksStore.WebUI.App_Start;
using BooksStore.WebUI.Infrastructure.Binders;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;

namespace BooksStore.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new EFDBInitializer());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegistreGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
        }
    }
}
