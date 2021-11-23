using System;

namespace Tilbake.MVC.Models
{
    public class PolicyRiskObjectViewModel
    {
        public Guid Id { get; set; }
        public AllRiskViewModel AllRisk { get; set; }
        public BuildingViewModel Building { get; set; }
        public ContentViewModel Content { get; set; }
        public HouseViewModel House { get; set; }
        public MotorViewModel Motor { get; set; }
    }
}
