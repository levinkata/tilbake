using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.API.Resources
{
    public class ClientSaveResource
    {
        public Guid TitleId { get; set; }
        public Guid ClientTypeId { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string MiddleName { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter Name"), MaxLength(50)]
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Guid GenderId { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter ID Number"), MaxLength(50)]
        public string IdNumber { get; set; }
        public Guid MaritalStatusId { get; set; }
        public Guid CountryId { get; set; }

        [MaxLength(50)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter Mobile Number"), MaxLength(50)]
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter Email ID")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }
        public Guid CarrierId { get; set; }
        public Guid OccupationId { get; set; }
    }
}
