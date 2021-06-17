﻿using System;

namespace Tilbake.API.Resources
{
    public class BankBranchSaveResource : BaseSaveResource
    {
        public string SortCode { get; set; }
        public string SwiftCode { get; set; }
        public Guid BankId { get; set; }
    }
}
