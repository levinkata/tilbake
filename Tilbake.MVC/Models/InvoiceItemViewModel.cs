using System;
using Tilbake.Core.Models;

namespace Tilbake.MVC.Models
{
    public class InvoiceItemViewModel
    {
        public Guid Id { get; set; }
        public Guid InvoiceId { get; set; }
        public Guid PolicyRiskId { get; set; }

        public PolicyRisk PolicyRisk { get; set; }
    }
}