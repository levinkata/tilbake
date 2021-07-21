using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;

namespace Tilbake.MVC.ViewComponents
{
    public class ClientDocumentsViewComponent : ViewComponent
    {
        private readonly IClientDocumentService _clientDocumentService;

        public ClientDocumentsViewComponent(IClientDocumentService clientDocumentService)
        {
            _clientDocumentService = clientDocumentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid clientId)
        {
            ViewBag.ClientId = clientId;
            return View(await Task.Run(() => _clientDocumentService.GetByClientIdAsync(clientId)).ConfigureAwait(true));
        }
    }
}
