using egdbooking_v2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Globalization;
using System.Threading;
using System.Linq;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http.Extensions;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;

namespace egdbooking_v2.Controllers
{
    public class BaseController : Controller
    {
        protected const string APPLICATION_CULTURE_EN = "en";
        protected const string APPLICATION_CULTURE_FR = "fr";
        protected const string QUERY_CULTURE_EN = "en";
        protected const string QUERY_CULTURE_FR = "fr";

        protected ApplicationDbContext db;
        public BaseController(ApplicationDbContext _db)
        {
            db = _db;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            string cultureName = (string)Request.Query["lang"];
            if (String.IsNullOrEmpty(cultureName))
            {
                if (Request.Headers["Referer"].ToString() != null)
                {
                    Uri ub = new Uri(Request.GetDisplayUrl());
                    Dictionary<string, StringValues> query = QueryHelpers.ParseQuery(ub.Query);
                    if (query.Count > 0 && query["lang"].Count() > 0)
                    {
                        cultureName = query["lang"].ToString();
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
            CultureInfo ci = new CultureInfo(cultureName);

            CultureInfo.CurrentCulture = ci;
            CultureInfo.CurrentUICulture = ci;
        }

        
        public IActionResult SetCulture(string lang)
        {
            var uri = new Uri(Request.Headers["Referer"]);
            var AbsolutePath = uri.AbsolutePath;
            var ReferrerQuery = uri.Query;
            var QueryPattern = @"(lang=)([A-z]{2})";
            var MatchQuery = Regex.Match(ReferrerQuery, QueryPattern);
            string NextQuery;
            if (MatchQuery.Success)
                NextQuery = Regex.Replace(ReferrerQuery, QueryPattern, "$1" + lang);
            else
                NextQuery = "?lang=fr";
            return Redirect(AbsolutePath + NextQuery);
        }
    }
}
