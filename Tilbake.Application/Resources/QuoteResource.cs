using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Application.Resources
{
    public class QuoteResource
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }

        [Display(Name = "Quote Number")]
        public int QuoteNumber { get; set; }

        [Display(Name = "Date")]
        public DateTime QuoteDate { get; set; }

        [Display(Name = "Quote Status")]
        public Guid QuoteStatusId { get; set; }

        [Display(Name = "Client Info")]
        public string ClientInfo { get; set; }

        [Display(Name = "Internal Info")]
        public string InternalInfo { get; set; }

        //  Descriptions
        [Display(Name = "Quote Status")]
        public string QuoteStatus { get; set; }

        //  SelectLists

        public SelectList QuoteStatuses { get; set; }

    }
}
