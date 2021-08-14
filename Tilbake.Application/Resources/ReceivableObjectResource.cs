using System;

namespace Tilbake.Application.Resources
{
    public class ReceivableObjectResource
    {
        public Guid PolicyId { get; set; }
        public ReceivableSaveResource Receivable { get; set; }
        public PremiumSaveResource Premium { get; set; }
    }
}
