using System;
using System.ComponentModel.DataAnnotations;
using Tilbake.Core.Enums;

namespace Tilbake.MVC.Models
{
    public class PremiumGiroViewModel
    {
        public Guid PortfolioId { get; set; }
        public Guid FileTemplateId { get; set; }

        public string TableName { get; set; }
        public FileType FileType { get; set; }

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
        public Guid IdNumberId { get; set; }

        [Display(Name = "Id Number")]
        public string IdNumberFieldLabel { get; set; }
        public string IdNumberPosition { get; set; }
        public int IdNumberColumnLength { get; set; }
        public bool IdNumberIsKey { get; set; }
        public Guid PolicyNumberId { get; set; }

        [Display(Name = "Policy Number")]
        public string PolicyNumberFieldLabel { get; set; }
        public string PolicyNumberPosition { get; set; }
        public int PolicyNumberColumnLength { get; set; }
        public bool PolicyNumberIsKey { get; set; }
        public Guid PremiumId { get; set; }

        [Display(Name = "Premium")]
        public string PremiumFieldLabel { get; set; }
        public string PremiumPosition { get; set; }
        public int PremiumColumnLength { get; set; }
        public bool PremiumIsKey { get; set; }

        //  Descriptions
        public string PortfolioName { get; set; }
        public string FileTemplate { get; set; }
    }
}
