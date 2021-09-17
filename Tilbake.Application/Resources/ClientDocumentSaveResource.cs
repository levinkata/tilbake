using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Application.Resources
{
    public class ClientDocumentSaveResource
    {
        public Guid ClientId { get; set; }
        public Guid PortfolioId { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Type")]
        public Guid DocumentTypeId { get; set; }

        public IFormFile File { get; set; }

        //  SelectLists

        public SelectList DocumentTypeList { get; set; }
    }
}
