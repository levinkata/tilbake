using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Application.Resources
{
    public class PortfolioClientSaveResource
    {
        public Guid PortfolioId { get; set; }
        public string PortfolioName { get; set; }

        [Display(Name = "Client Status")]
        public Guid ClientStatusId { get; set; }

        public ClientSaveResource Client { get; set; }

        //  SelectLists
        public SelectList ClientStatusList { get; set; }        
    }
}
