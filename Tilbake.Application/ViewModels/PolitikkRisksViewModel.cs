using System;
using System.Collections.Generic;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class PolitikkRisksViewModel
    {
        public Guid PolitikkID { get; set; }
        public IEnumerable<PolitikkRisk> PolitikkRisks { get; set; }
    }
}
