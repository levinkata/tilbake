using System;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Resources
{
    public class QuoteObjectResource
    {
        public Guid ClientId { get; set; }

        public QuoteResource Quote { get; set; }
        public QuoteItemResource[] QuoteItems  { get; set; }

        //  Risk Arrays
        public AllRiskResource[] AllRisks { get; set; }
        public AllRiskSpecifiedResource[] AllRiskSpecifieds { get; set; }
        public BuildingResource[] Buildings { get; set; }
        public ContentResource[] Contents { get; set; }
        public ExcessBuyBackResource[] ExcessBuyBacks { get; set; }
        public HouseResource[] Houses { get; set; }
        public MotorResource[] Motors { get; set; }
        public TravelResource[] Travels { get; set; }
        public RiskItemResource[] RiskItems { get; set; }
        public RiskItemResource[] SpecifiedRiskItems { get; set; }
    }
}
