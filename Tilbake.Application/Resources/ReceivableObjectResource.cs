using System;

namespace Tilbake.Application.Resources
{
    public class ReceivableObjectResource
    {
        public Guid PolicyId { get; set; }
        public InvoiceSaveResource InvoiceResource { get; set; }
        public ReceivableSaveResource ReceivableResource { get; set; }
        public PremiumSaveResource PremiumResource { get; set; }
    }
}
