﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilbake.Application.Resources
{
    public class ClientSearchResource
    {
        public string SearchString { get; set; }
        public IEnumerable<ClientResource> ClientResources { get; set; }
    }
}
