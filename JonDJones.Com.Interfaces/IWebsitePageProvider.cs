using Umbraco.Core.Models;

namespace JonDJones.Com.Interfaces
{
    public interface IWebsitePageProvider
    {
        IPublishedContent Homepage { get; }

        IPublishedContent GetPageBasedOnUmbracoId(int id);

        string SafeValueGet(IContent content, string propertyName);
    }
}
