using System;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Resources
{
    public class PolicyObjectResource
    {
        public Guid ClientId { get; set; }

        public Policy Policy { get; set; }
        public PolicyRisk[] PolicyRisks { get; set; }

        //  Risk Arrays
        public AllRisk[] AllRisks { get; set; }
        public Content[] Contents { get; set; }
        public House[] Houses { get; set; }
        public Motor[] Motors { get; set; }
        public RiskItem[] RiskItems { get; set; }
    }
}
