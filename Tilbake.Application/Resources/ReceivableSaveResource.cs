using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Application.Resources
{
    public class ReceivableSaveResource
    {
        public Guid InvoiceId { get; set; }
        public Guid QuoteId { get; set; }

        [Display(Name = "Reference")]
        public string Reference { get; set; }

        [Display(Name = "Date")]
        public DateTime ReceivableDate { get; set; }

        [Display(Name = "Payment Type")]
        public Guid PaymentTypeId { get; set; }

        [Display(Name = "Amount")]
        public decimal Amount { get; set; }

        [Display(Name = "Batch Number")]
        public string BatchNumber { get; set; }

        //  Descriptions
        [Display(Name = "Payment Type")]
        public string PaymentType { get; set; }

        //  SelectLists
        public SelectList PaymentTypeList { get; set; }
    }
}
