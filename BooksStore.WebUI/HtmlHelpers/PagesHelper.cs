using BooksStore.WebUI.Models;
using System;
using System.Text;
using System.Web.Mvc;

namespace BooksStore.WebUI.HtmlHelpers
{
    public static class PagesHelper
    {
        public static MvcHtmlString Pagination(this HtmlHelper helper, PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            StringBuilder elements = new StringBuilder();
            int numberIterations = pagingInfo.TotalPages + 1 > 4 ? 4 : pagingInfo.TotalPages + 1;
            bool prevFlag, nextFlag;
            bool activeFlag = false;
            for (int i = 0; i <= numberIterations; i++)
            {
                TagBuilder li = new TagBuilder("li");
                li.AddCssClass("page-item");
                TagBuilder a = new TagBuilder("a");
                a.AddCssClass("page-link");
                prevFlag = nextFlag = false;
                if (i == 0)
                {
                    a.InnerHtml = "Previous";
                    if (pagingInfo.CurrentPage - 1 > 0)
                        a.MergeAttribute("href", pageUrl(pagingInfo.CurrentPage - 1));
                    else
                    {
                        a.MergeAttribute("href", "#");
                        prevFlag = true;
                    }
                }
                else if (i == numberIterations)
                {
                    a.InnerHtml = "Next";
                    if (pagingInfo.CurrentPage + 1 <= pagingInfo.TotalPages)
                        a.MergeAttribute("href", pageUrl(pagingInfo.CurrentPage + 1));
                    else
                    {
                        a.MergeAttribute("href", "#");
                        nextFlag = true;
                    }
                }
                else
                {
                    if (pagingInfo.CurrentPage >= numberIterations)
                    {
                        a.InnerHtml = (pagingInfo.CurrentPage - 3 + i).ToString();
                        a.MergeAttribute("href", pageUrl(pagingInfo.CurrentPage - 3 + i));
                        activeFlag = true;
                    }
                    else
                    {
                        a.InnerHtml = i.ToString();
                        a.MergeAttribute("href", pageUrl(i));
                    }
                }
                li.InnerHtml = a.ToString();
                if (!activeFlag)
                {
                    if (i == pagingInfo.CurrentPage)
                        li.AddCssClass("active");
                }
                else
                {
                    if (i == numberIterations - 1)
                        li.AddCssClass("active");
                }
                if (prevFlag || nextFlag)
                    li.AddCssClass("disabled");
                elements.Append(li.ToString());
            }
            return MvcHtmlString.Create(elements.ToString());
        }
    }
}