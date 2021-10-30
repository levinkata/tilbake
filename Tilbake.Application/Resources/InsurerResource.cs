using System.Collections.Generic;
using Tilbake.Core.Models;

namespace Tilbake.Application.Resources
{
    public class InsurerResource : BaseResource
    {
        public List<InsurerBranch> InsurerBranches { get; } = new();
    }
}
