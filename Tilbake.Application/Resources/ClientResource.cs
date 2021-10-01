using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Application.Resources
{
    public class ClientResource
    {
        string _firstName = string.Empty;

        public Guid Id { get; set; }
        public Guid PortfolioId { get; set; }
        public Guid PortfolioClientId { get; set; }

        [Display(Name = "Title")]
        public Guid TitleId { get; set; }

        [Display(Name = "Client Number")]
        public int ClientNumber { get; set; }

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

        //  Descriptions
        public string PortfolioName { get; set; }

        //  Tables
        
        [Display(Name = "Client Type")]        
        public string ClientType { get; set; }

        [Display(Name = "Nationality")]  
        public string Country { get; set; }

        [Display(Name = "ID Document Type")]
        public string IdDocumentType { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Marital Status")]        
        public string MaritalStatus { get; set; }

        [Display(Name = "Occupation")]
        public string Occupation { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        public List<ClientCarrierResource> ClientCarriers = new List<ClientCarrierResource>();
        
        public List<EmailAddressResource> EmailAddresses = new List<EmailAddressResource>();
        public List<MobileNumberResource> MobileNumbers = new List<MobileNumberResource>();
        
        public AddressResource Address { get; set; }

        //  SelectLists

        public SelectList ClientTypeList { get; set; }
        public SelectList CountryList { get; set; }
        public SelectList EmailAddressList { get; set; }
        public SelectList GenderList { get; set; }
        public SelectList IdDocumentTypeList { get; set; }
        public SelectList MaritalStatusList { get; set; }
        public SelectList MobileNumberList { get; set; }
        public SelectList OccupationList { get; set; }
        public SelectList TitleList { get; set; }
    }
}