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
    public class PortfolioClientService : IPortfolioClientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PortfolioClientService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(PortfolioClientSaveResource resource)
        {
            var resourceClient = resource.Client;
            var clientId = resource.ClientId;

            var client = _mapper.Map<ClientSaveResource, Client>(resourceClient);

            if(client != null)
            {
                client.Id = Guid.NewGuid();
                client.DateAdded = DateTime.Now;
                _unitOfWork.Clients.Add(client);
                clientId = client.Id;
            }

            var portfolioClient = _mapper.Map<PortfolioClientSaveResource, PortfolioClient>(resource);

            portfolioClient.Id = Guid.NewGuid();
            portfolioClient.ClientId = clientId;
            portfolioClient.DateAdded = DateTime.Now;
            _unitOfWork.PortfolioClients.Add(portfolioClient);

            var resourceAddress = resource.Client.Address;
            
            if (resourceAddress != null)
            {
                var address = _mapper.Map<AddressSaveResource, Address>(resourceAddress);

                address. Id = Guid.NewGuid();
                address.ClientId = clientId;
                address.DateAdded = DateTime.Now;
                _unitOfWork.Addresses.Add(address);
            }
            
            var resourceEmailAddresses = resource.Client.EmailAddresses;
            if (resourceEmailAddresses != null)
            {
                var emailAddresses = _mapper.Map<IEnumerable<EmailAddressSaveResource>, IEnumerable<EmailAddress>>(resourceEmailAddresses);

                foreach (var emailAddress in emailAddresses)
                {
                    emailAddress.Id = Guid.NewGuid();
                    emailAddress.ClientId = clientId;
                    emailAddress.DateAdded = DateTime.Now;
                    _unitOfWork.EmailAddresses.Add(emailAddress);
                }
            }            

            var resourceMobileNumbers = resource.Client.MobileNumbers;
            if (resourceMobileNumbers != null)
            {
                var mobileNumbers = _mapper.Map<IEnumerable<MobileNumberSaveResource>, IEnumerable<MobileNumber>>(resourceMobileNumbers);
                foreach (var mobileNumber in mobileNumbers)
                {
                    mobileNumber.Id = Guid.NewGuid();
                    mobileNumber.ClientId = clientId;
                    mobileNumber.DateAdded = DateTime.Now;
                    _unitOfWork.MobileNumbers.Add(mobileNumber);
                }
            }  

            var carrierIds = resource.Client.CarrierIds;
            if (carrierIds != null)
            {
                foreach (var carrierId in carrierIds)
                {
                    ClientCarrier newClientCarrier = new()
                    {
                        ClientId = clientId,
                        CarrierId = carrierId,
                        DateAdded = DateTime.Now
                    };
                    _unitOfWork.ClientCarriers.Add(newClientCarrier);
                }
            }
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.PortfolioClients.Delete(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<bool> ExistsAsync(Guid portfolioId, Guid clientId)
        {
            var result = await _unitOfWork.PortfolioClients.GetAsync(
                                                            e => e.PortfolioId == portfolioId &&
                                                            e.ClientId == clientId,
                                                            null,
                                                            e => e.Client,
                                                            e => e.Client.Addresses,
                                                            e => e.Client.ClientCarriers,
                                                            e => e.Client.EmailAddresses,
                                                            e => e.Client.MobileNumbers,
                                                            e => e.Portfolio);
            
            return result.Any();
        }

        public async Task<PortfolioClientResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.PortfolioClients.GetAsync(
                                                            e => e.Id == id,
                                                            e => e.OrderBy(n => n.Client.LastName),
                                                            e => e.Client,
                                                            e => e.Client.Addresses,
                                                            e => e.Client.ClientCarriers,
                                                            e => e.Client.EmailAddresses,
                                                            e => e.Client.MobileNumbers,
                                                            e => e.Portfolio);

            var resource = _mapper.Map<PortfolioClient, PortfolioClientResource>(result.FirstOrDefault());
            return resource;
        }

        public async Task<PortfolioClientResource> GetByIdNumberAsync(Guid portfolioId, string idNumber)
        {
            var result = await _unitOfWork.PortfolioClients.GetAsync(
                                                            e => e.PortfolioId == portfolioId &&
                                                            e.Client.IdNumber == idNumber,
                                                            e => e.OrderBy(n => n.Client.LastName),
                                                            e => e.Client,
                                                            e => e.Client.Addresses,
                                                            e => e.Client.ClientCarriers,
                                                            e => e.Client.EmailAddresses,
                                                            e => e.Client.MobileNumbers,
                                                            e => e.Portfolio);

            var resource = _mapper.Map<PortfolioClient, PortfolioClientResource>(result.FirstOrDefault());
            return resource;
        }

        public async Task<PortfolioClientResource> GetByPortfolioClientAsync(Guid portfolioId, Guid clientId)
        {
            var result = await _unitOfWork.PortfolioClients.GetAsync(
                                                            e => e.PortfolioId == portfolioId &&
                                                            e.ClientId == clientId,
                                                            e => e.OrderBy(n => n.Client.LastName),
                                                            e => e.Client,
                                                            e => e.Client.Addresses,
                                                            e => e.Client.ClientCarriers,
                                                            e => e.Client.EmailAddresses,
                                                            e => e.Client.MobileNumbers,
                                                            e => e.Portfolio);

            var resource = _mapper.Map<PortfolioClient, PortfolioClientResource>(result.FirstOrDefault());
            return resource;
        }

        public async Task<IEnumerable<PortfolioClientResource>> GetByPortfolioIdAsync(Guid portfolioId)
        {
            var result = await _unitOfWork.PortfolioClients.GetAsync(
                                                            e => e.PortfolioId == portfolioId,
                                                            e => e.OrderBy(n => n.Client.LastName),
                                                            e => e.Client,
                                                            e => e.Client.Addresses,
                                                            e => e.Client.ClientCarriers,
                                                            e => e.Client.EmailAddresses,
                                                            e => e.Client.MobileNumbers,
                                                            e => e.Portfolio);

            var resources = _mapper.Map<IEnumerable<PortfolioClient>, IEnumerable< PortfolioClientResource>>(result);
            return resources;
        }

        public async Task<Guid> GetPortfolioClientId(Guid portfolioId, Guid clientId)
        {
            var result = await _unitOfWork.PortfolioClients.GetAsync(
                                            e => e.PortfolioId == portfolioId && e.ClientId == clientId);

            return result.FirstOrDefault().Id;
        }

        public async Task<int> UpdateAsync(PortfolioClientResource resource)
        {
            var portfolioClient = _mapper.Map<PortfolioClientResource, PortfolioClient>(resource);
            portfolioClient.DateModified = DateTime.Now;

            _unitOfWork.PortfolioClients.Update(resource.Id, portfolioClient);
            return await _unitOfWork.SaveAsync();
        }
    }
}
