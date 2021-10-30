using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tilbake.Core.Models;

namespace Tilbake.Application.Resources
{
    public class PortfolioClientResource
    {
        public Guid Id { get; set; }

        [Display(Name = "Portfolio")]
        public Guid PortfolioId { get; set; }

        [Display(Name = "Client")]
        public Guid ClientId { get; set; }

        [Display(Name = "Client Status")]
        public Guid ClientStatusId { get; set; }

        [Display(Name = "Withdrawal")]
        public bool IsWithdrawal { get; set; }

        public List<ClientCarrier> ClientCarriers = new();

        public List<EmailAddress> EmailAddresses = new();
        public List<MobileNumber> MobileNumbers = new();

        public List<Address> Addresses = new();

        public virtual Client Client { get; set; }
        public virtual ClientStatus ClientStatus { get; set; }
        public virtual Portfolio Portfolio { get; set; }

        //  Carriers
        [Display(Name = "Carriers")]
        public Guid[] CarrierIds { get; set; }

        public MultiSelectList CarrierList { get; set; }

        //  Address
        [Display(Name = "Physical Address")]
        public string PhysicalAddress { get; set; }

        [Display(Name = "Postal Address")]
        public string PostalAddress { get; set; }

        [Display(Name = "City")]
        public Guid? CityId { get; set; }

        [Display(Name = "Country")]
        public Guid AddressCountryId { get; set; }

        public SelectList CityList { get; set; }
        public SelectList AddressCountryList { get; set; }

        //  SelectLists
        public SelectList ClientTypeList { get; set; }
        public SelectList ClientStatusList { get; set; }
        public SelectList CountryList { get; set; }
        public SelectList GenderList { get; set; }
        public SelectList IdDocumentTypeList { get; set; }
        public SelectList MaritalStatusList { get; set; }
        public SelectList OccupationList { get; set; }
        public SelectList TitleList { get; set; }

    }
}