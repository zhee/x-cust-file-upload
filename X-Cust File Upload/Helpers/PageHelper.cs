using System;
using System.Web;
using System.Web.Mvc;

namespace X_Cust_File_Upload.Helpers
{
    public class PageHelper
    {
        public static MvcHtmlString Script(string paramSource, bool isSite)
        {
            if (isSite == true)
            {
                paramSource = GetSiteRoot() + "/Assets/sites/js/" + paramSource;
            }
            else
            {
                paramSource = GetSiteRoot() + "/Assets/libs/" + paramSource;
            }

            return MvcHtmlString.Create("<script type=\"text/javascript\" src=\"" + paramSource + "\"></script>");
        }

        public static MvcHtmlString CSS(string paramSource, bool isSite)
        {
            if (isSite == true)
            {
                paramSource = GetSiteRoot() + "/Assets/sites/css/" + paramSource;
            }
            else
            {
                paramSource = GetSiteRoot() + "/Assets/libs/" + paramSource;
            }
            
            return MvcHtmlString.Create("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + paramSource + "\" />");
        }

        public static MvcHtmlString Image(string paramId, string paramClass, string paramSource, string paramAlt)
        {
            paramSource = GetSiteRoot() + "/Assets/sites/images/" + paramSource;
            return MvcHtmlString.Create("<img src=\"" + paramSource + "\" alt=\"" + paramAlt + "\" id=\"" + paramId + "\" class=\"" + paramClass + "\" />");
        }

        //public static MvcHtmlString LibraryScript(string source)
        //{
        //    source = GetSiteRoot() + "/Assets/libs/" + source;
        //    return MvcHtmlString.Create("<script type=\"text/javascript\" src=\"" + source + "\"></script>");
        //}

        //public static MvcHtmlString LibraryCSS(string paramSource)
        //{
        //    paramSource = GetSiteRoot() + "/Assets/libs/" + paramSource;
        //    return MvcHtmlString.Create("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + paramSource + "\" />");
        //}

        private static string GetSiteRoot()
        {
            return HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
        }
    }
}