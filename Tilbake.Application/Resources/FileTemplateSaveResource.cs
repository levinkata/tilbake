using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Resources
{
    public class FileTemplateSaveResource : BaseResource
    {
        public Guid PortfolioId { get; set; }

        [Display(Name = "File Type")]
        public string FileType { get; set; }

        [Display(Name = "Delimiter")]
        public string Delimiter { get; set; }

        //public List<FileTemplateRecord> FileTemplateRecords { get; } = new List<FileTemplateRecord>();

        //  SelectLists
        public SelectList FileFormatList { get; set; }
    }
}