using System;
using System.Collections.Generic;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class KlientDocumentsViewModel
    {
        public Guid KlientID { get; set; }
        public IEnumerable<KlientDocument> KlientDocuments { get; set; }
    }
}
