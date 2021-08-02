using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Application.Resources
{
    public class FileTemplateSaveResource : BaseResource
    {
        public Guid PortfolioId { get; set; }
        public string PortfolioName { get; set; }

        [Display(Name = "File Type")]
        public string FileType { get; set; }

        [Display(Name = "Delimiter")]
        public string Delimiter { get; set; }

        //public List<FileTemplateRecord> FileTemplateRecords { get; } = new List<FileTemplateRecord>();

        //  SelectLists
        public SelectList FileFormatList { get; set; }
    }
}