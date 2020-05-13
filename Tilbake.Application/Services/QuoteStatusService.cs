using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.ViewModels;
using Tilbake.Domain.Interfaces;

namespace Tilbake.Application.Services
{
    public class QuoteStatusService : IQuoteStatusService
    {
        private readonly IQuoteStatusRepository _quoteStatusRepository;

        public QuoteStatusService(IQuoteStatusRepository quoteStatusRepository)
        {
            _quoteStatusRepository = quoteStatusRepository;
        }

        public async Task<int> AddAsync(QuoteStatusViewModel model)
        {
            return await Task.Run(() => _quoteStatusRepository.AddAsync(model.QuoteStatus)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Task.Run(() => _quoteStatusRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<QuoteStatusesViewModel> GetAllAsync()
        {
            return new QuoteStatusesViewModel()
            {
                QuoteStatuses = await Task.Run(() => _quoteStatusRepository.GetAllAsync()).ConfigureAwait(true)
            };
        }

        public async Task<QuoteStatusViewModel> GetAsync(Guid id)
        {
            return new QuoteStatusViewModel()
            {
                QuoteStatus = await Task.Run(() => _quoteStatusRepository.GetAsync(id)).ConfigureAwait(true)
            };
        }

        public async Task<int> UpdateAsync(QuoteStatusViewModel model)
        {
            return await Task.Run(() => _quoteStatusRepository.UpdateAsync(model.QuoteStatus)).ConfigureAwait(true);
        }
    }
}
