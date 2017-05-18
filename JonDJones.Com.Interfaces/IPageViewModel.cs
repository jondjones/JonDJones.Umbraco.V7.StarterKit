using Umbraco.Web.Models;
using Vega.USiteBuilder;

namespace JonDJones.Com.Interfaces
{
    public interface IPageViewModel<out T> where T : DocumentTypeBase
    {
        ILayoutViewModel Layout { get; set; }

        T CurrentPage { get; }
    }
}