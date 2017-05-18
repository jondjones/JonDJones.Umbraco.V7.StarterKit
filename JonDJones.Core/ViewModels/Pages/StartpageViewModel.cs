using JonDJones.Com.Interfaces;
using JonDJones.Core.DocumentTypes;
using JonDJones.Core.ViewModels.Base;

namespace JonDJones.Core.ViewModels.Pages
{
    public class StartpageViewModel : BaseViewModel<Startpage>
    {
        public StartpageViewModel(Startpage currentPage, IWebsiteDependencies dependencies)
        : base(currentPage, dependencies)
        {
        }
    }
}
