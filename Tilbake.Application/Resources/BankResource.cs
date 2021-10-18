using System.Collections.Generic;

namespace Tilbake.Application.Resources
{
    public class BankResource : BaseResource
    {
        public List<BankBranchResource> BankBranches { get; } = new();
    }
}
