using System.ComponentModel.DataAnnotations;
using Tilbake.Domain.Enums;

namespace Tilbake.Application.Resources
{
    public class ClientGiroResource
    {
        public Guid PortfolioId { get; set; }
        public Guid FileTemplateId { get; set; }
        public string PortfolioName { get; set; }
        public string TableName { get; set; }
        public FileFormat FileFormat { get; set; }
        public string FileTemplateName { get; set; }

        public Guid TitleId { get; set; }

        [Display(Name = "Title")]
        public string TitleFieldLabel { get; set; }
        public string TitlePosition { get; set; }
        public int TitleColumnLength { get; set; }
        public bool TitleIsKey { get; set; }
        public Guid ClientTypeId { get; set; }

        [Display(Name = "Client Type")]
        public string ClientTypeFieldLabel { get; set; }
        public string ClientTypePosition { get; set; }
        public int ClientTypeColumnLength { get; set; }
        public bool ClientTypeIsKey { get; set; }
        public Guid FirstNameId { get; set; }

        [Display(Name = "First Name")]
        public string FirstNameFieldLabel { get; set; }
        public string FirstNamePosition { get; set; }
        public int FirstNameColumnLength { get; set; }
        public bool FirstNameIsKey { get; set; }
        public Guid LastNameId { get; set; }

        [Display(Name = "Last Name")]
        public string LastNameFieldLabel { get; set; }
        public string LastNamePosition { get; set; }
        public int LastNameColumnLength { get; set; }
        public bool LastNameIsKey { get; set; }
        public Guid BirthDateId { get; set; }

        [Display(Name = "Birth Date")]
        public string BirthDateFieldLabel { get; set; }
        public string BirthDatePosition { get; set; }
        public int BirthDateColumnLength { get; set; }
        public bool BirthDateIsKey { get; set; }
        public Guid GenderId { get; set; }

        [Display(Name = "Gender")]
        public string GenderFieldLabel { get; set; }
        public string GenderPosition { get; set; }
        public int GenderColumnLength { get; set; }
        public bool GenderIsKey { get; set; }
        public Guid IdNumberId { get; set; }

        [Display(Name = "Id Number")]
        public string IdNumberFieldLabel { get; set; }
        public string IdNumberPosition { get; set; }
        public int IdNumberColumnLength { get; set; }
        public bool IdNumberIsKey { get; set; }

        public Guid MaritalStatusId { get; set; }

        [Display(Name = "Marital Status")]
        public string MaritalStatusFieldLabel { get; set; }
        public string MaritalStatusPosition { get; set; }
        public int MaritalStatusColumnLength { get; set; }
        public bool MaritalStatusIsKey { get; set; }

        public Guid PhoneId { get; set; }

        [Display(Name = "Phone")]
        public string PhoneFieldLabel { get; set; }
        public string PhonePosition { get; set; }
        public int PhoneColumnLength { get; set; }
        public bool PhoneIsKey { get; set; }
        public Guid MobileId { get; set; }

        [Display(Name = "Mobile")]
        public string MobileFieldLabel { get; set; }
        public string MobilePosition { get; set; }
        public int MobileColumnLength { get; set; }
        public bool MobileIsKey { get; set; }
        public Guid EmailId { get; set; }

        [Display(Name = "Email")]
        public string EmailFieldLabel { get; set; }
        public string EmailPosition { get; set; }
        public int EmailColumnLength { get; set; }
        public bool EmailIsKey { get; set; }
        public Guid CountryId { get; set; }

        [Display(Name = "Nationality")]
        public string CountryFieldLabel { get; set; }
        public string CountryPosition { get; set; }
        public int CountryColumnLength { get; set; }
        public bool CountryIsKey { get; set; }
        public Guid OccupationId { get; set; }

        [Display(Name = "Occupation")]
        public string OccupationFieldLabel { get; set; }
        public string OccupationPosition { get; set; }
        public int OccupationColumnLength { get; set; }
        public bool OccupationIsKey { get; set; }
    }
}
