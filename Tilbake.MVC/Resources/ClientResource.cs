using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.MVC.Resources
{
    public class ClientResource
    {
        public Guid Id { get; set; }

        [Display(Name = "Title")]
        public Guid TitleId { get; set; }

        [Display(Name = "Client Number")]
        public int ClientNumber { get; set; }

        [Display(Name = "Client Type")]
        public Guid ClientTypeId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Birth Date")]        
        public DateTime BirthDate { get; set; }

        [Display(Name = "Gender")]
        public Guid GenderId { get; set; }

        [Display(Name = "ID Number")]
        public string IdNumber { get; set; }

        [Display(Name = "Marital Status")]
        public Guid MaritalStatusId { get; set; }

        [Display(Name = "Nationality")]
        public Guid CountryId { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Mobile")]
        public string Mobile { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Carrier")]
        public Guid CarrierId { get; set; }

        [Display(Name = "Occupation")]
        public Guid OccupationId { get; set; }

        //  Descriptions
        
        [Display(Name = "Carrier")]
        public string Carrier { get; set; }

        [Display(Name = "Client Type")]        
        public string ClientType { get; set; }

        [Display(Name = "Nationality")]        
        public string Country { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Marital Status")]        
        public string MaritalStatus { get; set; }

        [Display(Name = "Occupation")]
        public string Occupation { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }
    }
}