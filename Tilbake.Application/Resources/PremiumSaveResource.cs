using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Application.Resources
{
    public class PremiumSaveResource
    {
        public Guid Id { get; set; }
        public Guid PolicyId { get; set; }

        [Display(Name = "Date")]
        public DateTime PremiumDate { get; set; }

        [Display(Name = "Month")]
        public int PremiumMonth { get; set; }

        [Display(Name = "Year")]
        public int PremiumYear { get; set; }

        [Display(Name = "Amount")]
        public decimal Amount { get; set; }

        [Display(Name = "Is Refunded?")]
        public bool IsRefunded { get; set; }

        [Display(Name = "Commission")]
        public decimal Commission { get; set; }

        [Display(Name = "Tax Amount")]
        public decimal TaxAmount { get; set; }

        [Display(Name = "Policy Fee")]
        public decimal PolicyFee { get; set; }

        [Display(Name = "Admin Fee")]
        public decimal AdministrationFee { get; set; }
    }
}
