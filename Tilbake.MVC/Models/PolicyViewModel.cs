﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;
using Tilbake.Core.Models;

namespace Tilbake.MVC.Models
{
    public class PolicyViewModel
    {
        public Guid Id { get; set; }
        public Guid PortfolioClientId { get; set; }
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

        //  Descriptions
        public string BankAccount { get; set; }

        [Display(Name = "Insurer")]
        public string InsurerName { get; set; }        

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
        public PortfolioClient PortfolioClient { get; set; }
        public SelectList SalesTypeList { get; set; }

    }
}
