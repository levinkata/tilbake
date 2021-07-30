using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Resources
{
    public class PolicySaveResource
    {
        public Guid PortfolioClientId { get; set; }
        public Guid ClientId { get; set; }
        public Guid QuoteId { get; set; }

        [Display(Name = "Policy Number")]
        public int PolicyNumber { get; set; }

        [Display(Name = "Insurer Policy Number")]
        public string InsurerPolicyNumber { get; set; }

        [Display(Name = "PolicyType")]
        public Guid PolicyTypeId { get; set; }

        [Display(Name = "Run Day")]
        public int RunDay { get; set; }

        [Display(Name = "Payment Method")]
        public Guid PaymentMethodId { get; set; }

        [Display(Name = "Bank Account")]
        public Guid ClientBankAccountId { get; set; }

        [Display(Name = "Insurer")]
        public Guid InsurerId { get; set; }

        [Display(Name = "Cover Start Date")]
        public DateTime CoverStartDate { get; set; }

        [Display(Name = "Cover End Date")]
        public DateTime CoverEndDate { get; set; }

        [Display(Name = "Inception Date")]
        public DateTime InceptionDate { get; set; }

        [Display(Name = "Policy Status")]
        public Guid PolicyStatusId { get; set; }

        [Display(Name = "Sales Type")]
        public Guid SalesTypeId { get; set; }

        [Display(Name = "Comment")]
        public string Comment { get; set; }

        public List<PolicyRisk> QuoteItems { get; } = new List<PolicyRisk>();

        //  AllRisk
        [Display(Name = "Sum Insured")]
        public decimal AllRiskSumInsured { get; set; }

        [Display(Name = "Cover Type")]
        public Guid AllRiskCoverTypeId { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

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
        public Content Content { get; set; }
        public House House { get; set; }
        public Motor Motor { get; set; }

        //  SelectLists
        public SelectList BankAccountList { get; set; }
        public SelectList InsurerList { get; set; }
        public SelectList PaymentMethodList { get; set; }
        public SelectList PolicyStatusList { get; set; }
        public SelectList PolicyTypeList { get; set; }
        public SelectList SalesTypeList { get; set; }

        public SelectList CoverTypeList { get; set; }
        public SelectList BodyTypeList { get; set; }
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
