using Vega.USiteBuilder;

namespace JonDJones.Core.DocumentTypes
{
    [DocumentType(Name = "Menu Item Document Type",
        Description = "Creates a new menu item.",
        AllowedChildNodeTypes = new[] { typeof(SubMenu) })]
    public class MenuItem : DocumentTypeBase
    {
        [DocumentTypeProperty(UmbracoPropertyType.Textstring,
            Name = "Menu Title",
            Description = "Menu Title",
            Tab = "Menu")]
        public string MenuTitle { get; set; }

        [DocumentTypeProperty(UmbracoPropertyType.Textstring,
            Name = "Link Url",
            Tab = "Menu",
            Description = "Link Url")]
        public string LinkUrl { get; set; }

        [DocumentTypeProperty(UmbracoPropertyType.TrueFalse,
            Name = "Display Sub Menu",
            Tab = "Menu",
            Description = "Display Sub Menu")]
        public bool DisplaySubMenu { get; set; }
    }
}