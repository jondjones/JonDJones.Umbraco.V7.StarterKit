using System.Web.Mvc;
using JonDJones.Com.Interfaces;
using JonDJones.Core.Controllers.Base;
using JonDJones.Core.Helpers;
using JonDJones.Core.ViewModels.Pages;
using Umbraco.Web.Models;

namespace JonDJones.Core.Controllers.Pages
{
    [OutputCache(Duration = 10, CacheProfile = "OneMinute")]
    public class HomepageController : BaseController
    {
        public HomepageController(IWebsiteDependencies dependencies)
            : base(dependencies)
        {
        }

        public override ActionResult Index(RenderModel model)
        {
            Dependencies.CacheProvider.StoreString("KEY", "Logged In");
            var homepage = ModelProvider.GetHomepageModel(model.Content.Id);
            var homepageViewModel = new HomepageViewModel(homepage, Dependencies);
            return CurrentTemplate(homepageViewModel);
        }
    }
}