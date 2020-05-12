using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class KlientDocumentViewModel
    {
        public Guid KlientID { get; set; }
        public KlientDocument KlientDocument { get; set; }

        private readonly List<IFormFile> documentfiles = new List<IFormFile>();
        public List<IFormFile> DocumentFiles { get { return documentfiles; } }
    }
}
