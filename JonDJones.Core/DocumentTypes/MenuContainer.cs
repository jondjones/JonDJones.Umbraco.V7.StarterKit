using Vega.USiteBuilder;

namespace JonDJones.Core.DocumentTypes
{
    [DocumentType(Name = "Menu Container",
        Description = "This is the container for primary nav.",
        AllowedChildNodeTypes = new[] { typeof(Menu) })]
    public class MenuContainer : DocumentTypeBase
    {
    }
}
