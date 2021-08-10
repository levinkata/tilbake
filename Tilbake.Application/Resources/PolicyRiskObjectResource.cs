using System;

namespace Tilbake.Application.Resources
{
    public class PolicyRiskObjectResource
    {
        public Guid Id { get; set; }
        public AllRiskResource AllRisk { get; set; }
        public ContentResource Content { get; set; }
        public HouseResource House { get; set; }
        public MotorResource Motor { get; set; }
    }
}
