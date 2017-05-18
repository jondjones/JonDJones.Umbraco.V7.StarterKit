using System.Web.Mvc;
using JonDJones.Com.Interfaces;
using JonDJones.Core.Controllers.Base;
using JonDJones.Core.Helpers;
using Umbraco.Web.Models;
using JonDJones.Core.ViewModels.Pages;

namespace JonDJones.Core.Controllers.Pages
{
    [OutputCache(Duration = 10, CacheProfile = "OneMinute")]
    public class StartpageController : BaseController
    {
        public StartpageController(IWebsiteDependencies dependencies)
            : base(dependencies)
        {
        }

        public override ActionResult Index(RenderModel model)
        {
            Dependencies.CacheProvider.StoreString("KEY", "Logged In");
            var startpage = ModelProvider.GetStartpageModel(model.Content.Id);
            var startpageViewModel = new StartpageViewModel(startpage, Dependencies);
            return CurrentTemplate(startpageViewModel);
        }
    }
}