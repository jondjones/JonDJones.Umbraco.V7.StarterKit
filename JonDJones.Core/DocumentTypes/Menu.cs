using Vega.USiteBuilder;

namespace JonDJones.Core.DocumentTypes
{
    [DocumentType(Name = "Menu Document Type",
        Description = "Creates a new menu.",
        AllowedChildNodeTypes = new[] { typeof(MenuItem) })]
    public class Menu : DocumentTypeBase
    {
        [DocumentTypeProperty(UmbracoPropertyType.Textstring,
            Name = "Menu Name",
            Tab = "Menu",
            Description = "Menu Name")]
        public string MenuName { get; set; }
    }
}
