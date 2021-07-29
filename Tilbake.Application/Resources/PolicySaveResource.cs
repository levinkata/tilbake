using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Application.Resources
{
    public class PolicySaveResource
    {
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

        //  SelectLists
        public SelectList BankAccountList { get; set; }
        public SelectList InsurerList { get; set; }
        public SelectList PaymentMethodList { get; set; }
        public SelectList PolicyStatusList { get; set; }
        public SelectList PolicyTypeList { get; set; }
        public SelectList SalesTypeList { get; set; }
    }
}
