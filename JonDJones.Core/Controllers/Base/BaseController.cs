using JonDJones.Com.Interfaces;
using JonDJones.Core.Helpers;
using Umbraco.Web.Mvc;

namespace JonDJones.Core.Controllers.Base
{
    public class BaseController : RenderMvcController
    {
        public IWebsiteDependencies Dependencies { get; set; }

        public BaseController(IWebsiteDependencies dependencies)
        {
            Guard.ValidateObject(dependencies);
            Dependencies = dependencies;
        }
    }
}
