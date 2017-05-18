using System;
using System.Collections.Generic;
using System.Linq;
using JonDJones.Com.Interfaces;
using JonDJones.Core.Entities;
using JonDJones.Core.Helpers;
using JonDJones.Core.Resources;
using log4net;
using Umbraco.Core.Models;
using Vega.USiteBuilder;

namespace JonDJones.Core.ViewModels.Shared
{
    public class HeaderViewModel : IHeaderViewModel
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(HeaderViewModel));

        private readonly DocumentTypeBase _homePage;

        private readonly DocumentTypeBase _currentPage;

        private readonly IWebsiteDependencies _dependencies;
        
        private IEnumerable<INavigationItem> _menu;

        public HeaderViewModel(DocumentTypeBase homePage,
                               DocumentTypeBase currentPage,
                               IWebsiteDependencies dependencies)
        {
            Guard.ValidateObject(homePage);
            Guard.ValidateObject(currentPage);
            Guard.ValidateObject(dependencies);

            _homePage = homePage;
            _currentPage = currentPage;
            _dependencies = dependencies;
        }

        public IEnumerable<INavigationItem> Menu
        {
            get
            {
                if (_menu != null)
                    return _menu;

                _menu = CreateMenu();
                return _menu;
            }
        }

        public string PageName => _currentPage.Name;

        public string HomepageUrl => _homePage.NiceUrl;
        
        private IEnumerable<INavigationItem> CreateMenu()
        {

            var menuList = new List<NavigationItem>();

            var menu = _dependencies.DocumentTypeProvider.GetPrimaryMenu();

            if (menu == null)
                return Enumerable.Empty<INavigationItem>();

            var menuChildren = menu.Descendants();

            foreach (var topLevelItem in menuChildren.Where(x => x.ParentId == menu.Id).OrderBy(y=> y.SortOrder))
            {
                menuList.Add(CreateNavigationItem(topLevelItem, menuChildren.Where(y => y.ParentId == topLevelItem.Id).OrderBy(y => y.SortOrder)));
            }

            return menuList;
        }

        private NavigationItem CreateNavigationItem(IContent menuItem, IEnumerable<IContent> subMenuItems)
        {
            try
            {
                var navItem = new NavigationItem()
                {
                    Name = menuItem.Name,
                    Link = menuItem.GetValue<string>(GlobalConstants.PropertyNames.LinkUrl)
                };

                if (subMenuItems == null || !subMenuItems.Any())
                    return navItem;

                foreach (var subMenu in subMenuItems)
                {
                    navItem.SubMenuItems.Add(CreateSubNavigationItem(subMenu));
                }

                return navItem;
            }
            catch (Exception ex)
             {
                _log.Error("Failed To Generate Menu Item", ex);
            }

            return null;
        }

        private INavigationItem CreateSubNavigationItem(IContent x)
        {
            try
            {
                var navItem = new NavigationItem
                {
                    Name = x.Name,
                    Link = x.GetValue<string>(GlobalConstants.PropertyNames.LinkUrl),
                    ImageUrl = x.GetValue<string>(GlobalConstants.PropertyNames.ImageUrl)
                };

                return navItem;
            }
            catch (Exception ex)
            {
                _log.Error("Failed To Generate Menu Item", ex);
            }

            return null;
        }
    }
}
