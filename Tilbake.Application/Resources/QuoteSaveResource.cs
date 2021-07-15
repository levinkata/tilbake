using Microsoft.AspNetCore.Mvc.Rendering;
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

        [Display(Name = "Cover Type")]
        public Guid CoverTypeId { get; set; }

        [Display(Name = "Motor Make")]
        public Guid MotorMakeId { get; set; }

        [Display(Name = "Sum Insured")]
        public decimal SumInsured { get; set; }

        //  Risks
        public AllRisk AllRisk { get; set; }
        public Content Content { get; set; }
        public House House { get; set; }
        public Motor Motor { get; set; }

        //  Risk Collections
        public List<AllRisk> AllRisks { get; } = new List<AllRisk>();
        public List<Content> Contents { get; } = new List<Content>();
        public List<House> Houses { get; } = new List<House>();
        public List<Motor> Motors { get; } = new List<Motor>();

        //  Descriptions
        [Display(Name = "Quote Status")]
        public string QuoteStatus { get; set; }

        //  SelectLists
        public SelectList InsurerList { get; set; }
        public SelectList QuoteStatusList { get; set; }
        public SelectList BodyTypeList { get; set; }
        public SelectList CoverTypelList { get; set; }
        public SelectList DriverTypeList { get; set; }
        public SelectList MotorMakeList { get; set; }
        public SelectList MotorModelList { get; set; }
        public SelectList MotorUseList { get; set; }
    }
}
