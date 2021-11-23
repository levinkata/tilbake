using System.Collections.Generic;

namespace Tilbake.MVC.Models
{
    public class InsurerViewModel : BaseViewModel
    {
        public IEnumerable<InsurerBranchViewModel>? InsurerBranches { get; }
    }
}
