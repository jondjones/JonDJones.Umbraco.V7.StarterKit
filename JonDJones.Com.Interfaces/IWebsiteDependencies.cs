using Umbraco.Core.Services;
using Umbraco.Web;
using Umbraco.Web.Routing;

namespace JonDJones.Com.Interfaces
{
    public interface IWebsiteDependencies
    {
        IContentTypeService ContentTypeService { get; }

        IContentService ContentService { get; }

        UrlProvider UrlProvider { get; }

        UmbracoContext UmbracoContext { get; }

        ICacheProvider CacheProvider { get; }

        IDocumentTypeProvider DocumentTypeProvider { get; }
    }
}
