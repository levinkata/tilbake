using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

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

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Gender")]
        public Guid GenderId { get; set; }

        [Display(Name = "ID Document")]
        public string IdDocument { get; set; }

        [Display(Name = "ID Number")]
        public string IdNumber { get; set; }

        [Display(Name = "Marital Status")]
        public Guid MaritalStatusId { get; set; }

        [Display(Name = "Nationality")]
        public Guid CountryId { get; set; }

        [MaxLength(50)]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Mobile")]
        public string Mobile { get; set; }

        [Display(Name = "Mobile 1")]
        public string Mobile1 { get; set; }

        [Display(Name = "Mobile 2")]
        public string Mobile2 { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Email 1")]
        public string Email1 { get; set; }

        [Display(Name = "Email 2")]
        public string Email2 { get; set; }

        [Display(Name = "Occupation")]
        public Guid OccupationId { get; set; }

        //  Descriptions
        public string PortfolioName { get; set; }


        //  SelectLists

        public SelectList ClientTypeList { get; set; }
        public SelectList CountryList { get; set; }
        public SelectList GenderList { get; set; }
        public SelectList IdDocumentList { get; set; }
        public SelectList MaritalStatusList { get; set; }
        public SelectList OccupationList { get; set; }
        public SelectList TitleList { get; set; }
    }
}
