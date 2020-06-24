using Tilbake.Domain.Models;

namespace Tilbake.Application.Interfaces.Communication
{
    public class KlientResponse : BaseResponse<Klient>
    {
        public KlientResponse(Klient klient) : base(klient) { }

        public KlientResponse(string message) : base(message) { }
    }
}
