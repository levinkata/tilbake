﻿using System;

namespace Tilbake.MVC.Resources
{
    public class BankBranchResource : BaseResource
    {
        public string SortCode { get; set; }
        public string SwiftCode { get; set; }
        public Guid BankId { get; set; }
        public string BankName { get; set; }
    }
}