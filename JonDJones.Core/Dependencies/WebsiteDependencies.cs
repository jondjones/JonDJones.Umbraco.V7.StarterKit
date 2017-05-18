using JonDJones.Com.Interfaces;
using System.Web;
using JonDJones.Core.Dependencies.Cache;
using Umbraco.Core;
using Umbraco.Core.Services;
using Umbraco.Web;
using Umbraco.Web.Routing;

namespace JonDJones.Core.Dependencies
{
    public class WebsiteDependencies : IWebsiteDependencies
    {
        private IContentTypeService _contentTypeService;

        private IContentService _contentService;

        private IDocumentTypeProvider _documentTypeProvider;

        private UrlProvider _urlProvider;

        public ICacheProvider CacheProvider => new RedisCacheProvider();

        public IContentTypeService ContentTypeService
            =>
            _contentTypeService 
            ?? (_contentTypeService = ApplicationContext.Current.Services.ContentTypeService);

        public IContentService ContentService
            => _contentService
            ?? (_contentService = ApplicationContext.Current.Services.ContentService);

        public IDocumentTypeProvider DocumentTypeProvider
            => _documentTypeProvider
            ?? (_documentTypeProvider = new DocumentTypeProvider(ContentService));

        public UrlProvider UrlProvider
        {
            get
            { 
                if (_urlProvider != null)
                    return _urlProvider;

                if (UmbracoContext.Current == null)
                    return null;

                _urlProvider = UmbracoContext.Current.UrlProvider;
                _urlProvider.Mode = UrlProviderMode.AutoLegacy;
                return _urlProvider;
            }
        }

        public UmbracoContext UmbracoContext
        {
            get
            {
                var umbracoContext = UmbracoContext.Current;

                if (umbracoContext != null)
                    return umbracoContext;

                UmbracoContext.EnsureContext(new HttpContextWrapper(HttpContext.Current)
                    , ApplicationContext.Current
                    , new Umbraco.Web.Security.WebSecurity(new HttpContextWrapper(HttpContext.Current)
                        , ApplicationContext.Current)
                    , true);

                return UmbracoContext.Current;
            }
        }
    }
}