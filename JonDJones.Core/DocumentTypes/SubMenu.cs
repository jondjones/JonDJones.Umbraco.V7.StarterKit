using Vega.USiteBuilder;

namespace JonDJones.Core.DocumentTypes
{
    [DocumentType(Name = "Sub Menu",
        Description = "Creates a new sub level menu item that sits under a menu item.",
        AllowedChildNodeTypes = new[] { typeof(MenuItem), typeof(SubMenu) })]
    public class SubMenu : DocumentTypeBase
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

        [DocumentTypeProperty(UmbracoPropertyType.Textstring,
            Name = "Image Url",
            Description = "Image Url",
            Tab = "Menu")]
        public string ImageUrl { get; set; }
    }
}