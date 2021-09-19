using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;
using Tilbake.Domain.Enums;

namespace Tilbake.Application.Resources
{
    public class FileTemplateSaveResource
    {
        public Guid PortfolioId { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "File Type")]
        public FileType FileType { get; set; }

        [Display(Name = "Delimiter")]
        public string Delimiter { get; set; }

        //  Descriptions
        public string Portfolio { get; set; }

        //  SelectLists
        public SelectList FileTypeList { get; set; }
    }
}