using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Application.Resources
{
    public class FileTemplateResource : BaseResource
    {
        public Guid PortfolioId { get; set; }

        [Display(Name = "File Type")]
        public string FileType { get; set; }

        [Display(Name = "Delimiter")]
        public string Delimiter { get; set; }
    }
}