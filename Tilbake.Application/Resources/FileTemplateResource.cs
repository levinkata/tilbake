using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tilbake.Core.Enums;
using Tilbake.Core.Models;

namespace Tilbake.Application.Resources
{
    public class FileTemplateResource
    {
        public Guid Id { get; set; }
        public Guid PortfolioId { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "File Type")]
        public FileType FileType { get; set; }

        [Display(Name = "Delimiter")]
        public string Delimiter { get; set; }

        public List<FileTemplateRecord> FileTemplateRecords { get; } = new();

        //  Descriptions
        public string PortfolioName { get; set; }

        //  SelectLists
        public SelectList FileTypeList { get; set; }
    }
}