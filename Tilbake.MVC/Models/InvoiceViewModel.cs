using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tilbake.Core.Models;

namespace Tilbake.MVC.Models
{
    public class InvoiceViewModel
    {
        public Guid Id { get; set; }
        public Guid PolicyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Display(Name = "Customer Name")]
        public string FullName => String.IsNullOrEmpty(FirstName) ? LastName : FirstName + " " + LastName;

        [Display(Name = "Number")]
        public int InvoiceNumber { get; set; }

        [Display(Name = "Date")]
        public DateTime InvoiceDate { get; set; }

        [Display(Name = "Due Date")]
        public DateTime InvoiceDueDate { get; set; }

        [Display(Name = "Amount")]
        public decimal Amount { get; set; }

        public decimal TaxRate { get; set; }
        public decimal TaxAmount { get; set; }

        public decimal ReducingBalance { get; set; }
        public decimal InstallmentAmount { get; set; }

        [Display(Name = "Status")]
        public Guid InvoiceStatusId { get; set; }

        public List<InvoiceItem> InvoiceItems { get; } = new List<InvoiceItem>();
       
        public virtual InvoiceStatusViewModel InvoiceStatus {get; set; }

        //  SelectLists
        public SelectList InvoiceStatusList { get; set; }
    }
}
