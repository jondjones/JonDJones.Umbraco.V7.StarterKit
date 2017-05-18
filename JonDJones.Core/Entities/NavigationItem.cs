using System.Collections.Generic;
using System.Linq;
using JonDJones.Com.Interfaces;

namespace JonDJones.Core.Entities
{
    public class NavigationItem : INavigationItem
    {
        public NavigationItem()
        {
            SubMenuItems = new List<INavigationItem>();
        }

        public string Name { get; set; }

        public string Link { get; set; }   

        public List<INavigationItem> SubMenuItems { get; set; }

        public bool HasChildren => SubMenuItems != null && SubMenuItems.Any();

        public string ImageUrl { get; set; }
    }
}
