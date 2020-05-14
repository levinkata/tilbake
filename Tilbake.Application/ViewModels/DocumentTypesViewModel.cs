using System.Collections.Generic;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class DocumentTypesViewModel
    {
        public IEnumerable<DocumentType> DocumentTypes { get; set; }
    }
}
