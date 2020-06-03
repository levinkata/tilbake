using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.ViewModels;
using Tilbake.Domain.Interfaces;

namespace Tilbake.Application.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly IQuoteRepository _quoteRepository;

        public QuoteService(IQuoteRepository quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }

        public async Task<int> AddAsync(QuoteViewModel model)
        {
            return await Task.Run(() => _quoteRepository.AddAsync(model.Quote, model.QuoteItems)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Task.Run(() => _quoteRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<QuotesViewModel> GetAllAsync()
        {
            return new QuotesViewModel()
            {
                Quotes = await Task.Run(() => _quoteRepository.GetAllAsync()).ConfigureAwait(true)
            };
        }

        public async Task<QuoteViewModel> GetAsync(Guid id)
        {
            return new QuoteViewModel()
            {
                Quote = await Task.Run(() => _quoteRepository.GetAsync(id)).ConfigureAwait(true)
            };
        }

        public async Task<QuoteViewModel> GetByQuoteNumberAsync(int quoteNumber)
        {
            return new QuoteViewModel()
            {
                Quote = await Task.Run(() => _quoteRepository.GetByQuoteNumberAsync(quoteNumber)).ConfigureAwait(true)
            };
        }

        public async Task<QuotesViewModel> GetKlientAsync(Guid klientId)
        {
            return new QuotesViewModel()
            {
                Quotes = await Task.Run(() => _quoteRepository.GetKlientAsync(klientId)).ConfigureAwait(true)
            };
        }

        public async Task<int> UpdateAsync(QuoteViewModel model)
        {
            return await Task.Run(() => _quoteRepository.UpdateAsync(model.Quote)).ConfigureAwait(true);
        }
    }
}
