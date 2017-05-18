using System.Collections.Generic;

namespace JonDJones.Com.Interfaces
{
    public interface INavigationItem
    {
        string Name { get; set; }

        string Link { get; set; }

        string ImageUrl { get; set; }

        List<INavigationItem> SubMenuItems { get; set; }

        bool HasChildren { get; }
    }
}