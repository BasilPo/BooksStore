using System.Web.Mvc;

namespace BooksStore.WebUI.App_Start
{
    public class FilterConfig
    {
        public static void RegistreGlobalFilters(GlobalFilterCollection filters) => filters.Add(new HandleErrorAttribute());
    }
}