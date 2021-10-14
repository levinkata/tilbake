using System;

namespace Tilbake.Application.Resources
{
    public class QuoteItemObjectResource
    {
        public Guid Id { get; set; }
        public AllRiskResource AllRisk { get; set; }
        public BuildingResource Building { get; set; }
        public ContentResource Content { get; set; }
        public ExcessBuyBackResource ExcessBuyBack { get; set; }
        public HouseResource House { get; set; }
        public MotorResource Motor { get; set; }
    }
}
