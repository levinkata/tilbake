using System;
using System.ComponentModel.DataAnnotations;
using Tilbake.Domain.Enums;

namespace Tilbake.API.Resources
{
    public class SaveKlientResource
    {
        public Guid TitleId { get; set; }
        public int KlientNumber { get; set; }

        [EnumDataType(typeof(KlientType))]
        public string KlientType { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [EnumDataType(typeof(Gender))]
        public string Gender { get; set; }

        [Required(ErrorMessage = "ID Number is required")]
        [MaxLength(50)]
        public string IdNumber { get; set; }

        [MaxLength(50)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Mobile Number is required")]
        [MaxLength(50)]
        public string Mobile { get; set; }

        [MaxLength(50)]
        public string Fax { get; set; }

        [Required, MaxLength(50)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Enter a valid email address")]
        public string Email { get; set; }

        [EnumDataType(typeof(Carrier))]
        public string Carrier { get; set; }

        public Guid OccupationId { get; set; }
        public Guid LandId { get; set; }
    }
}
