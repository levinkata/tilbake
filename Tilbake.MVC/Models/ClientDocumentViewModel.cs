using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;
using Tilbake.Core.Models;

namespace Tilbake.MVC.Models
{
    public class ClientDocumentViewModel
    {
        public Guid Id { get; set; }
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

        public Client Client { get; set; }
        public DocumentType DocumentType { get; set; }

        //  Descriptions

        [Display(Name = "Type")]
        public string DocumentTypeName { get; set; }

        //  SelectLists

        public SelectList DocumentTypeList { get; set; }
    }
}