using System;
using System.ComponentModel;
using System.Web;

namespace JonDJones.Core.Helpers
{
    public static class Extensions
    {
        public static string WebsiteDomainUrl
        {
            get
            {
                if (HttpContext.Current.Request.Url.Port == 80)
                    return new UriBuilder(
                    HttpContext.Current.Request.Url.Scheme,
                    HttpContext.Current.Request.Url.Host).ToString().Trim('/');

                return new UriBuilder(
                    HttpContext.Current.Request.Url.Scheme,
                    HttpContext.Current.Request.Url.Host,
                    HttpContext.Current.Request.Url.Port).ToString().Trim('/');
            }
        }
    }
}
