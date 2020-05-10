using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tilbake.Domain.Enums;

namespace Tilbake.Domain.Models
{
    public class Klient
    {
        public Guid ID { get; set; }

        [Display(Name = "Title")]
        public Guid TitleID { get; set; }

        [Display(Name = "Client Number")]
        public int KlientNumber { get; set; }

        [Display(Name = "Client Type")]
        [EnumDataType(typeof(KlientType))]
        public string KlientType { get; set; }

        [Display(Name = "First Name"), StringLength(50)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name"), Required, StringLength(50)]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName => String.IsNullOrEmpty(FirstName) ? LastName : FirstName + " " + LastName;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
            ApplyFormatInEditMode = true)]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Gender")]
        [EnumDataType(typeof(Gender))]
        public string Gender { get; set; }

        [Display(Name = "ID Number"), StringLength(50)]
        [Required(ErrorMessage = "ID Number is required")]
        public string IDNumber { get; set; }

        [Display(Name = "Phone"), StringLength(50)]
        public string Phone { get; set; }

        [Display(Name = "Mobile"), StringLength(50)]
        [Required(ErrorMessage = "Mobile Number is required")]
        public string Mobile { get; set; }

        [Display(Name = "Fax"), StringLength(50)]
        public string Fax { get; set; }

        [Display(Name = "Email"), Required, StringLength(50)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Enter a valid email address")]
        public string Email { get; set; }

        [Display(Name = "Notification Delivery")]
        [EnumDataType(typeof(Carrier))]
        public string Carrier { get; set; }

        [Display(Name = "Occupation")]
        public Guid OccupationID { get; set; }

        [Display(Name = "Nationality")]
        public Guid LandID { get; set; }

        public virtual Land Land { get; private set; }
        public virtual Title Title { get; private set; }
        public virtual Occupation Occupation { get; private set; }
        public virtual IReadOnlyCollection<PortfolioKlient> PortfolioKlients { get; set; } = new HashSet<PortfolioKlient>();
    }
}
