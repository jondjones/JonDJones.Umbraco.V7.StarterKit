using JonDJones.Core.DocumentTypes;
using Vega.USiteBuilder;

namespace JonDJones.Core.Helpers
{
    public static class ModelProvider
    {
        public static DocumentTypeBase GetModel(int contentId)
        {
            return ContentHelper.GetByNodeId(contentId);
        }

        public static Startpage GetStartpageModel(int contentId)
        {
            return ContentHelper.GetByNodeId<Startpage>(contentId);
        }
    }
}
