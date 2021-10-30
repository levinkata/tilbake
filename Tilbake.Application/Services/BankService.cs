using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;
using Tilbake.Core.Models;
using Tilbake.Core;

namespace Tilbake.Application.Services
{
    public class BankService : IBankService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BankService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async void Add(BankSaveResource resource)
        {
            var bank = _mapper.Map<BankSaveResource, Bank>(resource);
            bank.Id = Guid.NewGuid();
            bank.DateAdded = DateTime.Now;

            _unitOfWork.Banks.Add(bank);
            await _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.Banks.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<BankResource>> GetAllAsync()
        {
            var result = await _unitOfWork.Banks.FindAllAsync(
                                            null,
                                            r => r.OrderBy(n => n.Name),
                                            r => r.BankBranches);

            var resources = _mapper.Map<IEnumerable<Bank>, IEnumerable<BankResource>>(result);
            return resources;
        }

        public async Task<BankResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Banks.GetByIdAsync(
                                            r => r.Id == id,
                                            r => r.BankBranches);

            var resource = _mapper.Map<Bank, BankResource>(result);
            return resource;
        }

        public async void Update(BankResource resource)
        {
            var bank = _mapper.Map<BankResource, Bank>(resource);
            bank.DateModified = DateTime.Now;
            _unitOfWork.Banks.Update(resource.Id, bank);

            await _unitOfWork.SaveAsync();
        }
    }
}