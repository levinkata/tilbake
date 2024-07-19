using System;
using Tilbake.Core.Models;

namespace Tilbake.MVC.Models
{
    public class PolicyObjectViewModel
    {
        public Guid CustomerId { get; set; }

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
