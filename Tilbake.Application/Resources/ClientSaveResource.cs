using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Application.Resources
{
    public class ClientSaveResource
    {
        string _firstName = string.Empty;

        [Display(Name = "Title")]
        public Guid TitleId { get; set; }

        [Display(Name = "Client Type")]
        public Guid ClientTypeId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName 
         { 
            get { return _firstName; }
            set { _firstName = value ?? string.Empty; }
        }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Birth Date")]        
        public DateTime BirthDate { get; set; }

        [Display(Name = "Gender")]
        public Guid GenderId { get; set; }

        [Display(Name = "ID Document Type")]
        public Guid IdDocumentTypeId { get; set; }

        [Display(Name = "ID Number")]
        public string IdNumber { get; set; }

        [Display(Name = "Marital Status")]
        public Guid MaritalStatusId { get; set; }

        [Display(Name = "Nationality")]
        public Guid CountryId { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Occupation")]
        public Guid OccupationId { get; set; }

        //  Carriers
        [Display(Name = "Carriers")]
        public List<Guid> CarrierIds { get; set; }

        //  Email Addresses
        [Display(Name = "Email Addresses")]
        public List<EmailAddressSaveResource> EmailAddresses { get; set; }

        //  Mobile Numbers
        [Display(Name = "Mobile Numbers")]        
        public List<MobileNumberSaveResource> MobileNumbers  { get; set; }
        
        public AddressSaveResource Address { get; set; }

        //  SelectLists

        public SelectList ClientTypeList { get; set; }
        public SelectList CountryList { get; set; }
        public SelectList GenderList { get; set; }
        public SelectList IdDocumentTypeList { get; set; }
        public SelectList MaritalStatusList { get; set; }
        public SelectList OccupationList { get; set; }
        public SelectList TitleList { get; set; }
        public MultiSelectList CarrierList { get; set; }        
    }
}