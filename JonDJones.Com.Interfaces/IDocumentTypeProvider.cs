using System.Collections.Generic;
using Umbraco.Core.Models;

namespace JonDJones.Com.Interfaces
{
    public interface IDocumentTypeProvider
    {
        IContent GetPrimaryMenu();
    }
}
