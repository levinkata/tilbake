using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.MVC.Resources
{
    public class BankBranchSaveResource : BaseSaveResource
    {
        [Required(ErrorMessage = "Please enter Sort Code"), MaxLength(50)]
        public string SortCode { get; set; }

        [MaxLength(50)]
        public string SwiftCode { get; set; }

        [Required(ErrorMessage = "Please select Bank")]
        public Guid BankId { get; set; }
    }
}
