using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Application.Resources
{
    public class ClientDocumentSaveResource
    {
        public Guid ClientId { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "File Type")]
        public string FileType { get; set; }

        [Display(Name = "File Extension")]
        public string Extension { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Date")]
        public DateTime DocumentDate { get; set; }

        [Display(Name = "Type")]
        public Guid DocumentTypeId { get; set; }

        [Display(Name = "Location")]
        public string DocumentPath { get; set; }

        public IFormFile File { get; set; }

        //  Descriptions

        [Display(Name = "Type")]
        public string DocumentType { get; set; }

        //  SelectLists

        public SelectList DocumentTypeList { get; set; }
    }
}
