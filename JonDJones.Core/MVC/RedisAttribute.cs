using System;
using System.Web.Mvc;
using JonDJones.Com.Interfaces;
using JonDJones.Core.Dependencies.Cache;
using JonDJones.Core.Resources;
using StructureMap.Attributes;
using Umbraco.Web;

namespace JonDJones.Core.MVC
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class RedisAttribute : ActionFilterAttribute, IExceptionFilter
    {
        [SetterProperty]
        public IWebsiteDependencies WebsiteDependencies => DependencyResolver.Current.GetService<IWebsiteDependencies>();


        public int Duration
        {
            get;
            set;
        }

        public string CacheKey
        {
            get;
            set;
        }

        public bool AppendUmbracoId
        {
            get;
            set;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (string.IsNullOrEmpty(CacheKey) ||ConfigSettings.Redis.UseRedis == false)
                return;

            var html = WebsiteDependencies.CacheProvider.GetValue(GetCacheKey());

            if (html == null)
                return;

            filterContext.Result = new ContentResult
            {
                Content = html.ToString(),
                ContentType = "text/html"
            };
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (ConfigSettings.Redis.UseRedis == false)
                return;

            var html = WebsiteDependencies.CacheProvider.GetValue(GetCacheKey());
            if (html == null)
                WebsiteDependencies.CacheProvider.StoreString(GetCacheKey(), filterContext.HttpContext.Response.Output.ToString());
        }

        public void OnException(ExceptionContext filterContext)
        {
        }

        private string GetCacheKey()
        {
            var cacheKey = CacheKey;
            if (AppendUmbracoId)
                cacheKey = CacheKey + GetCurrentPageId();

            return cacheKey;
        }
        private string GetCurrentPageId()
        {
            var umbracoHelper = new UmbracoHelper(UmbracoContext.Current);

            var currentItem = umbracoHelper.AssignedContentItem;
            return currentItem.Id.ToString();
        }
    }
}