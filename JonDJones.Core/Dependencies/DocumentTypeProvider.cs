using System.Collections.Generic;
using System.Linq;
using JonDJones.Com.Interfaces;
using JonDJones.Core.Helpers;
using JonDJones.Core.Resources;
using umbraco.cms.businesslogic.web;
using Umbraco.Core.Models;
using Umbraco.Core.Services;

namespace JonDJones.Core.Dependencies
{
    public class DocumentTypeProvider : IDocumentTypeProvider
    {
        private readonly IContentService _contentService;

        public DocumentTypeProvider(IContentService contentService)
        {
            Guard.ValidateObject(contentService);
            _contentService = contentService;
        }

        #region Menu
        public IContent GetPrimaryMenu()
        {
            var menus = GetMenus();
            return menus.FirstOrDefault(x => x.Name == GlobalConstants.PageNames.PrimaryNav);
        }

        private IEnumerable<IContent> GetMenus()
        {
            var menuPages = DocumentType.GetByAlias(GlobalConstants.Alias.Menu);
            return _contentService.GetContentOfContentType(menuPages.Id);
        }
        #endregion
    }
}
