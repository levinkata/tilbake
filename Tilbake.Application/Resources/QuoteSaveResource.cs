﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Resources
{
    public class QuoteSaveResource
    {
        public Guid PortfolioId { get; set; }

        public Guid PortfolioClientId { get; set; }

        [Display(Name = "Quote Number")]
        public int QuoteNumber { get; set; }

        [Display(Name = "Date")]
        public DateTime QuoteDate { get; set; }

        [Display(Name = "Status")]
        public Guid QuoteStatusId { get; set; }

        [Display(Name = "Client Info")]
        public string ClientInfo { get; set; }

        [Display(Name = "Internal Info")]
        public string InternalInfo { get; set; }

        public List<QuoteItem> QuoteItems { get; } = new List<QuoteItem>();

        //  Descriptions
        [Display(Name = "Quote Status")]
        public string QuoteStatus { get; set; }

        //  SelectLists

        public SelectList InsurerList { get; set; }
        public SelectList CoverageList { get; set; }
        public SelectList QuoteStatusList { get; set; }
    }
}
