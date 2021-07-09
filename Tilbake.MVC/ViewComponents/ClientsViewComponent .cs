using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;
using Tilbake.Domain.Models;

namespace Tilbake.MVC.ViewComponents
{
    public class ClientsViewComponent : ViewComponent
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public ClientsViewComponent(IClientService clientService,
                                IMapper mapper)
        {
            _clientService = clientService ?? throw new ArgumentNullException(nameof(clientService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid? portfolioId)
        {
            IEnumerable<Client> result;

            if (portfolioId == Guid.Empty)
            {
                result = await _clientService.GetAllAsync().ConfigureAwait(true);
            }
            else
            {
                result = await _clientService.GetByPortfolioIdAsync((Guid)portfolioId).ConfigureAwait(true);
                ViewBag.PortfolioId = portfolioId;
            }
            var resources = _mapper.Map<IEnumerable<Client>, IEnumerable<ClientResource>>(result);
            return View(resources);
        }
    }
}
