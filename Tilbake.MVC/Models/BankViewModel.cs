using System.Collections.Generic;

namespace Tilbake.MVC.Models
{
    public class BankViewModel : BaseViewModel
    {
        public IEnumerable<BankBranchViewModel>? BankBranches { get; }
    }
}
