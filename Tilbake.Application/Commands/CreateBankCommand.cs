using MediatR;
using Tilbake.Application.Interfaces.Communication;

namespace Tilbake.Application.Commands
{
    public class CreateBankCommand : IRequest<BankResponse>
    {
        public string Name { get; set; }        
    }
}