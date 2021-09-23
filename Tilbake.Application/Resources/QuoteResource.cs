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

        [Display(Name = "Insurer")]
        public Guid InsurerId { get; set; }

        [Display(Name = "Client Info")]
        public string ClientInfo { get; set; }

        [Display(Name = "Internal Info")]
        public string InternalInfo { get; set; }

        [Display(Name = "Debit Order Day")]
        public int RunDay { get; set; }

        public bool IsFulfilled { get; set;  }
        public bool IsPaid { get; set; }
        public bool IsPolicySet { get; set; }

        public List<QuoteItem> QuoteItems { get; } = new List<QuoteItem>();

        public Client Client { get; set; }
        public Insurer Insurer { get; set; }
        public PortfolioClient PortfolioClient { get; set; }

        //  Descriptions
        [Display(Name = "Quote Status")]
        public string QuoteStatus { get; set; }

        //  SelectLists
        public SelectList CoverTypeList { get; set; }
        public SelectList InsurerList { get; set; }
        public SelectList QuoteStatusList { get; set; }
    }
}
