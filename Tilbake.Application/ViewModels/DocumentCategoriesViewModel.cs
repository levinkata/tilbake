using System.Collections.Generic;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class DocumentCategoriesViewModel
    {
        public IEnumerable<DocumentCategory> DocumentCategories { get; set; }
    }
}
