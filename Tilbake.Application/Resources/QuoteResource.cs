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
        [Display(Name = "Insurer")]
        public Guid InsurerId { get ;set; }

        public virtual List<QuoteItem> QuoteItems { get; } = new List<QuoteItem>();

        //  Other
        public decimal TaxRate { get; set; }
        public string PortfolioName { get; set; }
        
        //  Tables
        public virtual ClientResource Client { get; set; }
        public virtual InsurerResource Insurer { get; set; }
        public virtual InsurerBranch InsurerBranch { get; set; }
        public virtual PaymentMethodResource PaymentMethod { get; set; }
        public virtual PolicyTypeResource PolicyType { get; set; }
        public virtual PortfolioClientResource PortfolioClient { get; set; }
        public virtual QuoteStatusResource QuoteStatus { get; set; }
        public virtual SalesTypeResource SalesType { get; set; }

        //  SelectLists
        public SelectList CoverTypeList { get; set; }
        public SelectList DayList { get; set; }
        public SelectList InsurerList { get; set; }
        public SelectList InsurerBranchList { get; set; }
        public SelectList QuoteStatusList { get; set; }

        public SelectList PaymentMethodList { get; set; }
        public SelectList PolicyTypeList { get; set; }
        public SelectList SalesTypeList { get; set; }
    }
}
