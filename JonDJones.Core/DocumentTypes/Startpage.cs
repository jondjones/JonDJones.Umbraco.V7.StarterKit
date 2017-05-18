using System;
using Vega.USiteBuilder;

namespace JonDJones.Core.DocumentTypes
{
    [DocumentType(
            Name = "Startpage",
            Description = "Startpage")]
    public class Startpage : DocumentTypeBase
    {
        [DocumentTypeProperty(UmbracoPropertyType.RichtextEditor,
            Name = "Content Area",
            Tab = "Content",
            Description = "Content Area")]
        public string ContentArea { get; set; }
    }
}
