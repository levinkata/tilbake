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
        public Guid ClientId { get; set; }
        public Guid PortfolioClientId { get; set; }

        [Display(Name = "Quote Number")]
        public int QuoteNumber { get; set; }

        [Display(Name = "Date")]
        public DateTime QuoteDate { get; set; }

        [Display(Name = "Status")]
        public Guid QuoteStatusId { get; set; }

        [Display(Name = "Insurer")]
        public Guid InsurerId { get; set; }

        [Display(Name = "Client Info")]
        public string ClientInfo { get; set; }

        [Display(Name = "Internal Info")]
        public string InternalInfo { get; set; }

        public List<QuoteItem> QuoteItems { get; } = new List<QuoteItem>();

        //  Other
        public Client Client { get; set; }

        //  AllRisk
        [Display(Name = "Sum Insured")]
        public decimal AllRiskSumInsured { get; set; }

        [Display(Name = "Cover Type")]
        public Guid AllRiskCoverTypeId { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        //  Building
        [Display(Name = "Sum Insured")]
        public decimal BuildingSumInsured { get; set; }

        [Display(Name = "Cover Type")]
        public Guid BuildingCoverTypeId { get; set; }

        //  Content
        [Display(Name = "Sum Insured")]
        public decimal ContentSumInsured { get; set; }

        [Display(Name = "Cover Type")]
        public Guid ContentCoverTypeId { get; set; }

        //  House
        [Display(Name = "Sum Insured")]
        public decimal HouseSumInsured { get; set; }

        [Display(Name = "Cover Type")]
        public Guid HouseCoverTypeId { get; set; }

        //  Motor
        [Display(Name = "Sum Insured")]
        public decimal MotorSumInsured { get; set; }

        [Display(Name = "Cover Type")]
        public Guid MotorCoverTypeId { get; set; }

        [Display(Name = "Motor Make")]
        public Guid MotorMakeId { get; set; }

        //  Risks
        public AllRisk AllRisk { get; set; }
        public Building Building { get; set; }
        public Content Content { get; set; }
        public House House { get; set; }
        public Motor Motor { get; set; }

        //  SelectLists
        public SelectList CoverTypeList { get; set; }
        public SelectList QuoteStatusList { get; set; }
        public SelectList BodyTypeList { get; set; }
        public SelectList BuildingConditionList { get; set; }
        public SelectList DayList { get; set; }
        public SelectList DriverTypeList { get; set; }
        public SelectList HouseConditionList { get; set; }
        public SelectList MotorMakeList { get; set; }
        public SelectList MotorModelList { get; set; }
        public SelectList MotorUseList { get; set; }
        public SelectList ResidenceTypeList { get; set; }
        public SelectList ResidenceUseList { get; set; }
        public SelectList RoofTypeList { get; set; }
        public SelectList WallTypeList { get; set; }
        public SelectList DateRangeList { get; set; }
    }
}
