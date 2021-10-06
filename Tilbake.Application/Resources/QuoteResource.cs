using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Resources
{
    public class QuoteResource
    {
        public Guid PortfolioId { get; set; }
        public Guid Id { get; set; }
        public Guid PortfolioClientId { get; set; }
        public Guid ClientId { get; set; }

        [Display(Name = "Quote Number")]
        public int QuoteNumber { get; set; }

        [Display(Name = "Date")]
        public DateTime QuoteDate { get; set; }

        [Display(Name = "Quote Status")]
        public Guid QuoteStatusId { get; set; }

        [Display(Name = "Insurer Branch")]
        public Guid InsurerBranchId { get; set; }

        [Display(Name = "Sales Type")]
        public Guid? SalesTypeId { get; set; }

        [Display(Name = "Policy Type")]
        public Guid? PolicyTypeId { get; set; }

        [Display(Name = "Payment Method")]
        public Guid? PaymentMethodId { get; set; }

        [Display(Name = "Client Info")]
        public string ClientInfo { get; set; }

        [Display(Name = "Internal Info")]
        public string InternalInfo { get; set; }

        [Display(Name = "Debit Order")]
        public int RunDay { get; set; }

        public bool IsFulfilled { get; set;  }
        public bool IsPaid { get; set; }
        public bool IsPolicySet { get; set; }

        // Other
        public Guid InsurerId { get ;set; }

        public List<QuoteItem> QuoteItems { get; } = new List<QuoteItem>();

        //  Other
        public decimal TaxRate { get; set; }
        public string PortfolioName { get; set; }
        
        //  Tables
        public Client Client { get; set; }
        public Insurer Insurer { get; set; }
        public InsurerBranch InsurerBranch { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public PolicyType PolicyType { get; set; }
        public PortfolioClient PortfolioClient { get; set; }
        public QuoteStatus QuoteStatus { get; set; }
        public SalesType SalesType { get; set; }

        //  SelectLists
        public SelectList CoverTypeList { get; set; }
        public SelectList DayList { get; set; }
        public SelectList InsurerList { get; set; }
        public SelectList InsurerBranchList { get; set; }
        public SelectList QuoteStatusList { get; set; }
    }
}
