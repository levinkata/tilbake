using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.MVC.Models
{
    public class BankBranchViewModel : BaseViewModel
    {
        [Display(Name = "Sort Code")]
        public string? SortCode { get; set; }

        [Display(Name = "Swift Code")]
        public string? SwiftCode { get; set; }

        [Display(Name = "Bank")]
        public Guid BankId { get; set; }

        public virtual BankViewModel? Bank { get; set; }
    }
}
