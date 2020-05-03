using System;
using System.Collections.Generic;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class BankBranchesViewModel
    {
        public Guid BankID { get; set; }
        public IEnumerable<BankBranch> BankBranches { get; set; }
    }
}
