using System.Web.Mvc;
using System.Web.Routing;

namespace BooksStore.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: null,
                url: "",
                defaults: new { controller = "Home", action = "Index" }
                );

            routes.MapRoute(
                name: null,
                url: "Page{page}",
                defaults: new { controller = "Book", action = "List", genre = (string)null, },
                constraints: new { page = @"\d+" }
                );

            routes.MapRoute(
                name: null,
                url: "{genre}",
                defaults: new { controller = "Book", action = "List", page = 1 }
                );

            routes.MapRoute(
                name: null,
                url: "{genre}/Page{page}",
                defaults: new { controller = "Book", action = "List" },
                constraints: new { page = @"\d+" }
                );

            routes.MapRoute(
                name: null,
                url: "{controller}/{action}");
        }
    }
}