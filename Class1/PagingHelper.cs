using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace TheMoviesHub.Class1
{
    public static class PagingHelper
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl) 
        {
            StringBuilder result = new StringBuilder();
            string anchorInnerHtml = "";
            for(int i = 1; i <= pagingInfo.TotalPages; i++) 
            {
                TagBuilder tag = new TagBuilder("a");
                anchorInnerHtml = AnchorInnerHtml(i, pagingInfo);

                if (anchorInnerHtml == "..")
                    tag.MergeAttribute("href", "#");
                else
                    tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = anchorInnerHtml;
                if(i == pagingInfo.CurrentPage) 
                {
                    tag.AddCssClass("active");
                }
                tag.AddCssClass("pagina");
                if(anchorInnerHtml == "")
                    result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }

        public static string AnchorInnerHtml(int i, PagingInfo pagingInfo) 
        {
            string anchorInnerHtml = "";
            if (pagingInfo.TotalPages <= 10)
                anchorInnerHtml = i.ToString();
            else 
            {
                if(pagingInfo.CurrentPage <= 5) 
                {
                    if ((i <= 8) || (i == pagingInfo.TotalPages))
                        anchorInnerHtml = i.ToString();
                    else if(i == pagingInfo.TotalPages -1)
                        anchorInnerHtml = "..";
                }
            }
            return anchorInnerHtml;
        }
        
    }
}