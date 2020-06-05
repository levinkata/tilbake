using Microsoft.AspNetCore.Http;
using System;

namespace Tilbake.Application.ViewModels
{
    public class FileUpLoadViewModel
    {
        public Guid KlientID { get; set; }
        public string Description { get; set; }
        public Guid DocumentTypeID { get; set; }
        public IFormFile DocumentFile { get; set; }
    }
}
