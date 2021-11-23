using System;

namespace Tilbake.MVC.Models
{
    public class ReceivableObjectViewModel
    {
        public Guid PolicyId { get; set; }
        public ReceivableViewModel Receivable { get; set; }
        public PremiumViewModel Premium { get; set; }
    }
}
