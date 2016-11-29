using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace egdBooking_v2.Controllers
{
    public class BaseController : Controller
    {
        protected const string APPLICATION_CULTURE_EN = "en";
        protected const string APPLICATION_CULTURE_FR = "fr";
        protected const string QUERY_CULTURE_EN = "en";
        protected const string QUERY_CULTURE_FR = "fr";

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            string cultureName = (string)Request.QueryString["lang"];
            if (String.IsNullOrEmpty(cultureName))
            {
                if (Request.UrlReferrer != null)
                {
                    UriBuilder ub = new UriBuilder(Request.UrlReferrer);
                    NameValueCollection query = HttpUtility.ParseQueryString(ub.Query);
                    if (query.Count > 0 && query.Get("lang").Count() > 0)
                    {
                        cultureName = query.Get("lang").ToString();
                    }
                    else
                    {
                        cultureName = QUERY_CULTURE_EN;
                    }
                }
                else
                {
                    cultureName = QUERY_CULTURE_EN;
                }
            }

            ViewBag.lang = cultureName;
            cultureName = cultureName.Equals(QUERY_CULTURE_FR) ? APPLICATION_CULTURE_FR : APPLICATION_CULTURE_EN;
            CultureInfo ci = CultureInfo.GetCultureInfo(cultureName);

            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

        public ActionResult SetCulture(string lang)
        {
            var Referrer = Request.UrlReferrer.ToString();
            var ReferrerRequest = new HttpRequest(null, Referrer, null);
            var HostName = ReferrerRequest.Url.GetLeftPart(UriPartial.Authority);
            var AbsolutePath = ReferrerRequest.Url.AbsolutePath;
            var ReferrerQuery = ReferrerRequest.Url.Query;
            var QueryPattern = @"(lang=)([A-z]{3})";
            var MatchQuery = Regex.Match(ReferrerQuery, QueryPattern);
            string NextQuery;
            if (MatchQuery.Success)
                NextQuery = Regex.Replace(ReferrerQuery, QueryPattern, "$1" + lang);
            else
                NextQuery = "?lang=fr";
            return Redirect(HostName + AbsolutePath + NextQuery);
        }
    }
}