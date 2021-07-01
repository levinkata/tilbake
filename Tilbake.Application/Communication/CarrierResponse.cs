using Tilbake.Domain.Models;

namespace Tilbake.Application.Communication
{
    public class CarrierResponse : BaseResponse<Carrier>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="Carrier">Saved Carrier.</param>
        /// <returns>Response.</returns>
        public CarrierResponse(Carrier Carrier) : base(Carrier)
        { 
            
        }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public CarrierResponse(string message) : base(message)
        { 

        }        
    }
}