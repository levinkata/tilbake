using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Resources
{
    public class ClientSaveResource
    {
        public Guid PortfolioId { get; set; }

        [Display(Name = "Title")]
        public Guid TitleId { get; set; }

        [Display(Name = "Client Type")]
        public Guid ClientTypeId { get; set; }

        [MaxLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter Name"), MaxLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Gender")]
        public Guid GenderId { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter ID Number"), MaxLength(50)]
        [Display(Name = "ID Number")]
        public string IdNumber { get; set; }

        [Display(Name = "Marital Status")]
        public Guid MaritalStatusId { get; set; }

        [Display(Name = "Nationality")]
        public Guid CountryId { get; set; }

        [MaxLength(50)]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter Mobile Number"), MaxLength(50)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile")]
        public string Mobile { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter Email ID")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Occupation")]
        public Guid OccupationId { get; set; }

        public List<ClientCarrier> ClientCarriers { get; } = new();

        public Guid[] CarrierIds { get; set; }

        //  Descriptions
        public string PortfolioName { get; set; }


        //  SelectLists

        public SelectList ClientTypeList { get; set; }
        public SelectList CountryList { get; set; }
        public SelectList GenderList { get; set; }
        public SelectList MaritalStatusList { get; set; }
        public SelectList OccupationList { get; set; }
        public SelectList TitleList { get; set; }
        public MultiSelectList CarrierList { get; set; }
    }
}
