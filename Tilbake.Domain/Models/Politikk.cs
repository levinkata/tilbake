using System;
using System.ComponentModel.DataAnnotations;
using Tilbake.Domain.Attributes;
using Tilbake.Domain.Enums;

namespace Tilbake.Domain.Models
{
    public class Politikk
    {
        public Guid ID { get; set; }
        public Guid PortfolioKlientID { get; set; }

        [Display(Name = "Policy Number"), Required, StringLength(50)]
        //[Remote(action: "IsPolitikkNumberAlreadyExist", controller: "Politikk", AdditionalFields = "ID")]
        public string PolitikkNumber { get; set; }

        [Display(Name = "Policy Type")]
        public Guid PolitikkTypeID { get; set; }

        [Display(Name = "Insurer")]
        public Guid InsurerID { get; set; }

        [Display(Name = "Cover Start Date"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
            ApplyFormatInEditMode = true)]
        [DateTimeCompare("CoverEndDate", ValueComparison.IsLessThan,
            ErrorMessage = "Cover Start Date must be earlier than Cover End Date.")]
        public DateTime CoverStartDate { get; set; }

        [Display(Name = "Cover End Date"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
            ApplyFormatInEditMode = true)]
        [DateTimeCompare("CoverStartDate", ValueComparison.IsGreaterThan,
            ErrorMessage = "Cover End Date must be later than Cover Start Date.")]
        public DateTime CoverEndDate { get; set; }

        [Display(Name = "Inception Date"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
            ApplyFormatInEditMode = true)]
        public DateTime InceptionDate { get; set; }

        [Display(Name = "Policy Status")]
        public Guid PolitikkStatusID { get; set; }

        [Display(Name = "Sales Type")]
        public Guid SalesTypeID { get; set; }

        [Display(Name = "Comment"), StringLength(100)]
        public string Comment { get; set; }

        public virtual Insurer Insurer { get; private set; }
        public virtual PolitikkStatus PolitikkStatus { get; private set; }
        public virtual PolitikkType PolitikkType { get; private set; }
        public virtual PortfolioKlient PortfolioKlient { get; private set; }
        public virtual SalesType SalesType { get; private set; }
    }
}
