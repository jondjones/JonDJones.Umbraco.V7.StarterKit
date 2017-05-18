using JonDJones.Com.Interfaces;
using JonDJones.Core.Helpers;
using Vega.USiteBuilder;

namespace JonDJones.Core.ViewModels.Shared
{
    public class LayoutViewModel : ILayoutViewModel
    {
        private readonly IWebsiteDependencies _dependencies;

        public LayoutViewModel (
            DocumentTypeBase currentPage, 
            IWebsiteDependencies dependencies)
        {
            Guard.ValidateObject(dependencies);
            _dependencies = dependencies;

            Url = Extensions.WebsiteDomainUrl + currentPage.Url;
        }

        public string SiteName { get;  }

        public string Url { get; }
    }
}
