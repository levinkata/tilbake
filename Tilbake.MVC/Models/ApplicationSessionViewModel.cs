using System;

namespace Tilbake.MVC.Models
{
    public class ApplicationSessionViewModel : BaseViewModel
    {
        public string Value { get; set; } = null!;
        public Guid UserId { get; set; }
    }
}
