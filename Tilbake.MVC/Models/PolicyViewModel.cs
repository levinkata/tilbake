﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;
using Tilbake.Core.Models;

namespace Tilbake.MVC.Models
{
    public class PolicyViewModel
    {
        public Guid Id { get; set; }
        public Guid PortfolioCustomerId { get; set; }
        public Guid CustomerId { get; set; }
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
        public Guid CustomerBankAccountId { get; set; }

        [Display(Name = "Insurer Branch")]
        public Guid InsurerBranchId { get; set; }

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

        //  Other
        public Guid InsurerId { get; set; }
        public int QuoteNumber { get; set; }
        public string FullName { get; set; }
        public string BankAccount { get; set; }

        [Display(Name = "Insurer")]
        public string InsurerName { get; set; }

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
        public AllRiskViewModel AllRisk { get; set; }
        public AllRiskSpecifiedViewModel AllRiskSpecified { get; set; }
        public BuildingViewModel Building { get; set; }
        public ContentViewModel Content { get; set; }
        public HouseViewModel House { get; set; }
        public MotorViewModel Motor { get; set; }
        public TravelViewModel Travel { get; set; }

        //  Tables
        public virtual InsurerBranchViewModel InsurerBranch { get; set; }
        public virtual PaymentMethodViewModel PaymentMethod { get; set; }
        public virtual PolicyStatusViewModel PolicyStatus { get; set; }
        public virtual PolicyTypeViewModel PolicyType { get; set; }
        public virtual SalesTypeViewModel SalesType { get; set; }

        //  SelectLists
        public SelectList BankAccountList { get; set; }
        public SelectList InsurerList { get; set; }
        public SelectList InsurerBranchList { get; set; }
        public SelectList PaymentMethodList { get; set; }
        public SelectList PolicyStatusList { get; set; }
        public SelectList PolicyTypeList { get; set; }
        public PortfolioCustomer PortfolioCustomer { get; set; }
        public SelectList SalesTypeList { get; set; }


        public SelectList CoverTypeList { get; set; }
        public SelectList DayList { get; set; }
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
