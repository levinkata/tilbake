﻿using System;
using System.ComponentModel.DataAnnotations;
using Tilbake.Core.Enums;

namespace Tilbake.MVC.Models
{
    public class CustomerGiroViewModel
    {
        public Guid PortfolioId { get; set; }
        public Guid FileTemplateId { get; set; }

        public string TableName { get; set; }
        public FileType FileType { get; set; }

        public Guid TitleId { get; set; }

        [Display(Name = "Title")]
        public string TitleFieldLabel { get; set; }
        public string TitlePosition { get; set; }
        public int TitleColumnLength { get; set; }
        public bool TitleIsKey { get; set; }

        public Guid CustomerTypeId { get; set; }

        [Display(Name = "Customer Type")]
        public string CustomerTypeFieldLabel { get; set; }
        public string CustomerTypePosition { get; set; }
        public int CustomerTypeColumnLength { get; set; }
        public bool CustomerTypeIsKey { get; set; }

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

        //  Descriptions
        public string PortfolioName { get; set; }
        public string FileTemplate { get; set; }
    }
}
