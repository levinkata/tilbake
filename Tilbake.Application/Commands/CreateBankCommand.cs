using MediatR;
using Tilbake.Application.Communication;

namespace Tilbake.Application.Commands
{
    public class CreateBankCommand : IRequest<BankResponse>
    {
        public string Name { get; set; }        
    }
}