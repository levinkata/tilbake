using System;
using System.Collections.Generic;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class AllRisksViewModel
    {
        public Guid KlientID { get; set; }
        public IEnumerable<AllRisk> AllRisks { get; set; }
    }
}
