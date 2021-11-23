using System;

namespace Tilbake.MVC.Models
{
    public class QuoteObjectViewModel
    {
        public Guid ClientId { get; set; }

        public QuoteViewModel Quote { get; set; }
        public QuoteItemViewModel[] QuoteItems  { get; set; }

        //  Risk Arrays
        public AllRiskViewModel[] AllRisks { get; set; }
        public AllRiskSpecifiedViewModel[] AllRiskSpecifieds { get; set; }
        public BuildingViewModel[] Buildings { get; set; }
        public ContentViewModel[] Contents { get; set; }
        public ExcessBuyBackViewModel[] ExcessBuyBacks { get; set; }
        public HouseViewModel[] Houses { get; set; }
        public MotorViewModel[] Motors { get; set; }
        public TravelViewModel[] Travels { get; set; }
        public TravelBeneficiaryViewModel[] TravelBeneficiaries { get; set; }
        public RiskItemViewModel[] RiskItems { get; set; }
        public RiskItemViewModel[] SpecifiedRiskItems { get; set; }
    }
}
