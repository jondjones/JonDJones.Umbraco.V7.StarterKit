using System.Linq;
using JonDJones.Com.Interfaces;
using JonDJones.Core.Helpers;
using JonDJones.Core.Resources;
using log4net;
using umbraco.cms.businesslogic.web;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Web;

namespace JonDJones.Core.Dependencies
{
    public class WebsitePageProvider : IWebsitePageProvider
    { 
        private readonly ILog _log = LogManager.GetLogger(typeof(WebsitePageProvider));

        private readonly UmbracoHelper _umbracoHelper;

        private IPublishedContent _homepage;

        public WebsitePageProvider(UmbracoHelper umbracoHelper)
        {
            Guard.ValidateObject(umbracoHelper);
            _umbracoHelper = umbracoHelper;
        }

        public IPublishedContent Homepage
        {
            get
            {
                if (_homepage != null)
                    return _homepage;

                var items = _umbracoHelper.TypedContentAtRoot();
                _homepage = items.FirstOrDefault(x => x.ContentType.Alias == GlobalConstants.Alias.Homepage);
                return _homepage;
            }
        }

        public IPublishedContent GetPageBasedOnUmbracoId(int id)
        {
            return  _umbracoHelper.TypedContent(id);
        }

        public string SafeValueGet(IContent content, string propertyName)
        {
            if (content == null)
                return string.Empty;

            var property = content.GetValue(propertyName);
            return property?.ToString() ?? string.Empty;
        }
       
    }
}