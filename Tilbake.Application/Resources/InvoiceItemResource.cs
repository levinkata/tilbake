using System;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Resources
{
    public class InvoiceItemResource
    {
        public Guid Id { get; set; }
        public Guid InvoiceId { get; set; }
        public Guid PolicyRiskId { get; set; }

        public PolicyRisk PolicyRisk { get; set; }
    }
}