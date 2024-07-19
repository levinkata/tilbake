using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.MVC.Models
{
    public class CustomerViewModel
    {
        string _firstName = string.Empty;

        public Guid Id { get; set; }
        public Guid PortfolioId { get; set; }
        public Guid PortfolioCustomerId { get; set; }

        [Display(Name = "Title")]
        public Guid TitleId { get; set; }

        [Display(Name = "Customer Number")]
        public int CustomerNumber { get; set; }

        [Display(Name = "Customer Type")]
        public Guid CustomerTypeId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value ?? string.Empty; }
        }

        [Display(Name = "Middle Name")]
        public string? MiddleName { get; set; }

        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Gender")]
        public Guid GenderId { get; set; }

        [Display(Name = "ID Document Type")]
        public Guid IdDocumentTypeId { get; set; }

        [Display(Name = "ID Number")]
        public string? IdNumber { get; set; }

        [Display(Name = "Marital Status")]
        public Guid MaritalStatusId { get; set; }

        [Display(Name = "Nationality")]
        public Guid CountryId { get; set; }

        [Display(Name = "Phone")]
        public string? Phone { get; set; }

        [Display(Name = "Occupation")]
        public Guid OccupationId { get; set; }

        //  Carriers
        [Display(Name = "Carriers")]
        public List<Guid>? CarrierIds { get; set; }

        //  Descriptions
        public string? PortfolioName { get; set; }

        //  Tables

        public virtual CustomerTypeViewModel? CustomerType { get; set; }
        public virtual CountryViewModel? Country { get; set; }
        public virtual IdDocumentTypeViewModel? IdDocumentType { get; set; }
        public virtual GenderViewModel? Gender { get; set; }
        public virtual MaritalStatusViewModel? MaritalStatus { get; set; }
        public virtual OccupationViewModel? Occupation { get; set; }
        public virtual TitleViewModel? Title { get; set; }

        public List<CustomerCarrierViewModel> CustomerCarriers = new();

        //  Email Addresses
        [Display(Name = "Email Addresses")]
        public List<EmailAddressViewModel> EmailAddresses = new();

        //  Mobile Numbers
        [Display(Name = "Mobile Numbers")]
        public List<MobileNumberViewModel> MobileNumbers = new();

        public List<AddressViewModel> Addresses = new();

        //  SelectLists
        public SelectList? CustomerTypeList { get; set; }
        public SelectList? CountryList { get; set; }
        //public SelectList? EmailAddressList { get; set; }
        public SelectList? GenderList { get; set; }
        public SelectList? IdDocumentTypeList { get; set; }
        public SelectList? MaritalStatusList { get; set; }
        //public SelectList? MobileNumberList { get; set; }
        public SelectList? OccupationList { get; set; }
        public SelectList? TitleList { get; set; }
        public MultiSelectList? CarrierList { get; set; }
    }
}
