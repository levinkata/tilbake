using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tilbake.Core.Models;

namespace Tilbake.Application.Resources
{
    public class ReceivableResource
    {
        public Guid Id { get; set; }
        public Guid InvoiceId { get; set; }

        [Display(Name = "Reference")]
        public string Reference { get; set; }

        [Display(Name = "Date")]
        public DateTime? ReceivableDate { get; set; }

        [Display(Name = "Payment Type")]
        public Guid PaymentTypeId { get; set; }

        [Display(Name = "Amount")]
        public decimal? Amount { get; set; }

        [Display(Name = "Batch Number")]
        public string BatchNumber { get; set; }

        public List<ReceivableDocument> ReceivableDocuments { get; } = new List<ReceivableDocument>();
        public List<ReceivableInvoice> ReceivableInvoices { get; } = new List<ReceivableInvoice>();

        //  Descriptions
        [Display(Name = "Payment Type")]
        public string PaymentType { get; set; }

        //  SelectLists
        public SelectList PaymentTypeList { get; set; }
    }
}
