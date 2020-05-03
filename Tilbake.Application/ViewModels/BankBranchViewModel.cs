using System;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class BankBranchViewModel
    {
        public Guid BankID { get; set; }
        public BankBranch BankBranch { get; set; }
    }
}
