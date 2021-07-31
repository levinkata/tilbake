using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Tilbake.Application.Resources
{
    public class InvoiceSaveResource
    {
        public Guid PolicyId { get; set; }

        [Display(Name = "Invoice Number")]
        public int InvoiceNumber { get; set; }

        [Display(Name = "Invoice Date")]
        public DateTime InvoiceDate { get; set; }

        [Display(Name = "Invoice Due Date")]
        public DateTime InvoiceDueDate { get; set; }

        [Display(Name = "Amount")]
        public decimal Amount { get; set; }
        public Guid TaxId { get; set; }
        public decimal TaxAmount { get; set; }

        [Display(Name = "Invoice Status")]
        public Guid InvoiceStatusId { get; set; }

        //  Descriptions

        [Display(Name = "Invoice Status")]        
        public string InvoiceStatus {get; set; }

        [Display(Name = "Tax")]
        public string Tax {get; set; }

        //  SelectLists
        public SelectList InvoiceStatusList { get; set; }
        public SelectList TaxList { get; set; }
    }
}
