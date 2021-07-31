using System;

namespace Tilbake.Application.Resources
{
    public class InvoiceItemSaveResource
    {
        public Guid Id { get; set; }
        public Guid InvoiceId { get; set; }
        public Guid PolicyRiskId { get; set; }
    }
}