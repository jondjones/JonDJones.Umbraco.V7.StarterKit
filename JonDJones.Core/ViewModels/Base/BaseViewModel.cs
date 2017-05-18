using JonDJones.Com.Interfaces;
using JonDJones.Core.Helpers;
using Vega.USiteBuilder;

namespace JonDJones.Core.ViewModels.Base
{
    public class BaseViewModel<T> : IPageViewModel<T> where T : DocumentTypeBase
    {
        public BaseViewModel(T currentPage, IWebsiteDependencies dependencies)
        {
            Guard.ValidateObject(currentPage);
            Guard.ValidateObject(dependencies);

            CurrentPage = currentPage;
            WebsiteDependencies = dependencies;
        }

        public int Id => CurrentPage.Id;

        public T CurrentPage { get; private set; }

        public ILayoutViewModel Layout { get; set; }

        public IWebsiteDependencies WebsiteDependencies { get; set; }
    }
}
