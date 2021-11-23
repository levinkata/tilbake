using System;

namespace Tilbake.MVC.Models
{
    public class CityViewModel : BaseViewModel
    {
        public Guid CountryId { get; set; }

        public virtual CountryViewModel? Country { get; set; }
    }
}
