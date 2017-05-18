using Umbraco.Core.Models;

namespace JonDJones.Core.Helpers
{
    public static class UmbracoContentHelper
    {
        public static bool HasPropertyValue(IContent content, string propertyAlias)
        {
            return content.HasProperty(propertyAlias) && content.GetValue(propertyAlias) != null;
        }
    }
}
