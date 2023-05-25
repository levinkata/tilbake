using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tilbake.Core.Models;

namespace Tilbake.MVC.Models
{
    public class QuoteViewModel
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

        //[Display(Name = "Sales Type")]
        //public Guid? SalesTypeId { get; set; }

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
        //public decimal TaxRate { get; set; }
        public string PortfolioName { get; set; }
        public virtual List<QuoteItemViewModel> QuoteItems { get; } = new List<QuoteItemViewModel>();

        //  Tables
        public virtual ClientViewModel Client { get; set; }
        public virtual InsurerViewModel Insurer { get; set; }
        public virtual InsurerBranchViewModel InsurerBranch { get; set; }
        public virtual PaymentMethodViewModel PaymentMethod { get; set; }
        public virtual PolicyTypeViewModel PolicyType { get; set; }
        public virtual PortfolioClientViewModel PortfolioClient { get; set; }
        public virtual QuoteStatusViewModel QuoteStatus { get; set; }
        //public virtual SalesTypeViewModel SalesType { get; set; }

        //  AllRisk - Specified
        [Display(Name = "Sum Insured")]
        public decimal AllRiskSpecifiedSumInsured { get; set; }

        [Display(Name = "Cover Type")]
        public Guid AllRiskSpecifiedCoverTypeId { get; set; }

        [Display(Name = "Description")]
        public string AllRiskSpecifiedDescription { get; set; }

        //  AllRisk - Unspecified
        [Display(Name = "Sum Insured")]
        public decimal AllRiskSumInsured { get; set; }

        [Display(Name = "Cover Type")]
        public Guid AllRiskCoverTypeId { get; set; }

        [Display(Name = "Description")]
        public string AllRiskDescription { get; set; }

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

        //  Travel
        [Display(Name = "Sum Insured")]
        public decimal TravelSumInsured { get; set; }

        [Display(Name = "Cover Type")]
        public Guid TravelCoverTypeId { get; set; }

        //  Risks
        public AllRiskViewModel AllRisk { get; set; }
        public AllRiskSpecified AllRiskSpecified { get; set; }
        public BuildingViewModel Building { get; set; }
        public ContentViewModel Content { get; set; }
        public HouseViewModel House { get; set; }
        public MotorViewModel Motor { get; set; }
        public TravelViewModel Travel { get; set; }

        //  SelectLists
        public SelectList BodyTypeList { get; set; }
        public SelectList BuildingConditionList { get; set; }
        public SelectList CountryList { get; set; }
        public SelectList CoverTypeList { get; set; }
        public SelectList DriverTypeList { get; set; }
        public SelectList HouseConditionList { get; set; }
        public SelectList InsurerList { get; set; }
        public SelectList InsurerBranchList { get; set; }
        public SelectList MotorMakeList { get; set; }
        public SelectList MotorModelList { get; set; }
        public SelectList MotorUseList { get; set; }
        public SelectList PaymentMethodList { get; set; }
        public SelectList PolicyTypeList { get; set; }
        public SelectList QuoteStatusList { get; set; }
        public SelectList ResidenceTypeList { get; set; }
        public SelectList ResidenceUseList { get; set; }
        public SelectList RoofTypeList { get; set; }
        public SelectList SalesTypeList { get; set; }
        public SelectList TitleList { get; set; }
        public SelectList WallTypeList { get; set; }

    }
}
