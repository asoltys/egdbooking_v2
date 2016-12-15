using Microsoft.AspNetCore.Mvc.Filters;
using System.Globalization;
using Microsoft.AspNetCore.Routing;

namespace src.Helpers
{
    public class CultureSettingResourceFilter : IResourceFilter, IOrderedFilter
    {
        public int Order
        {
            get
            {
                return int.MinValue;
            }
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            // By this time the response would already have been started, so do not try to modify the response
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            if (context.HttpContext.Request.Query["lang"].ToString() != null)
            { 
                CultureInfo culture = new CultureInfo(context.HttpContext.Request.Query["lang"].ToString());
                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;
            }
        }
    }
}
