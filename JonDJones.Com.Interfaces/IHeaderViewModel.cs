using System.Collections.Generic;

namespace JonDJones.Com.Interfaces
{
    public interface IHeaderViewModel
    {
        IEnumerable<INavigationItem> Menu { get; }
    }
}
