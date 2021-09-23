﻿using System;
using System.ComponentModel.DataAnnotations;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Resources
{
    public class BankBranchResource : BaseResource
    {
        [Display(Name = "Sort Code")]
        public string SortCode { get; set; }

        [Display(Name = "Swift Code")]
        public string SwiftCode { get; set; }

        [Display(Name = "Bank")]
        public Guid BankId { get; set; }

        public Bank Bank { get; set; }
    }
}
