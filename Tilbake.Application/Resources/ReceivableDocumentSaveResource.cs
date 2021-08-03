using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Application.Resources
{
    public class ReceivableDocumentSaveResource
    {
        public Guid ReceivableId { get; set; }

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

        [Display(Name = "Document Type")]
        public Guid DocumentTypeId { get; set; }

        [Display(Name = "Document Path")]
        public string DocumentPath { get; set; }

        //  Descriptions
        [Display(Name = "Document Type")]
        public string DocumentType { get; set; }
    }
}
